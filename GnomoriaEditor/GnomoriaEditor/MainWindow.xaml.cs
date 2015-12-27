using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Game;
using GameLibrary;
using Microsoft.Win32;
using Microsoft.Xna.Framework;

namespace GnomoriaEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private FileInfo File { get; set; }
        private IEnumerable<Faction> EnemyFactions { get; set; }
        public ObservableCollection<GnomeRow> Gnomes { get; set; }
        public List<Profession> Professions { get; set; }
        public List<EnemyRow> Enemies { get; set; }

        private ItemCreator itemCreator;

        private bool gameloaded;
        private bool GameLoaded
        {
            set
            {
                HeadingLabel.Content = value ? GnomanEmpire.Instance.World.AIDirector.PlayerFaction.Name : "Game not loaded";

                SaveButton.IsEnabled = value;

                RevealMapButton.IsEnabled = value;
                RevealOreButton.IsEnabled = value;
                ExpandOreButton.IsEnabled = value;
                AddItemButton.IsEnabled = value;
                IrrigateButton.IsEnabled = value;
                FixGhostItemsButton.IsEnabled = value;
                gameloaded = value;
            }
        }

        private IEnumerable<GnomeRow> SelectedGnomeRows
        {
            get { return GnomeGrid.SelectedItems.Cast<GnomeRow>(); }
        }

        private IEnumerable<EnemyRow> SelectedEnemyRows
        {
            get { return EnemyGrid.SelectedItems.Cast<EnemyRow>(); }
        }

        public MainWindow()
        {
            Gnomes = new ObservableCollection<GnomeRow>();
            Professions = new List<Profession>();
            Enemies = new List<EnemyRow>();

            InitializeComponent();
            InitializeTabs();
            InitializeGnomoria();

            ProgressBar.Visibility = Visibility.Hidden;
            GameLoaded = false;
            ShowWorld(null, null);

            ItemList.ItemsSource = ItemRow.GetItems();
            MaterialList.ItemsSource = MaterialRow.GetMaterials();
            //QualityList.ItemsSource = QualityRow.GetQualities();
            ItemList.SelectedIndex = 145;
            MaterialList.SelectedIndex = 59;
            //QualityList.SelectedIndex = 5;
        }

        private static void InitializeGnomoria()
        {
            var initializeMethod = typeof(GnomanEmpire).GetMethod("Initialize", BindingFlags.Instance | BindingFlags.NonPublic);
            initializeMethod.Invoke(GnomanEmpire.Instance, null);

            GnomanEmpire.Instance.AudioManager.SetMusicVolume(0);
            if (GnomanEmpire.Instance.Graphics.IsFullScreen)
                GnomanEmpire.Instance.Graphics.ToggleFullScreen();
        }

        private void InitializeTabs()
        {
            foreach (var item in Tab.Items.Cast<TabItem>())
            {
                item.Visibility = Visibility.Collapsed;
            }
        }

        private void Open(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            EndGnomeEdit();

            var dlg = new OpenFileDialog
            {
                Filter = "Gnomoria saves|*.sav",
                DefaultExt = ".sav",
                InitialDirectory = GnomanEmpire.SaveFolderPath() + "Worlds"
            };
            var result = dlg.ShowDialog(this);

            if (result == false)
            {
                return;
            }

            LoadButton.IsEnabled = false;
            Clear();

            ProgressBar.Visibility = Visibility.Visible;
            HeadingLabel.Content = "Game loading...";

            File = new FileInfo(dlg.FileName);

            var worker = new BackgroundWorker();
            worker.DoWork += LoaderLoad;
            worker.RunWorkerCompleted += LoaderComplete;
            worker.RunWorkerAsync();
        }

        private void LoaderLoad(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            GnomanEmpire.Instance.LoadGame(File.Name);
            if (File.Directory != null)
                File.CopyTo(Path.Combine(File.Directory.FullName, Path.GetFileNameWithoutExtension(File.Name)) + ".backup", true);

            UpdateGame();

            foreach (var profession in GnomanEmpire.Instance.Fortress.Professions)
            {
                Professions.Add(profession);
            }

            LoadGnomes();

            EnemyFactions = GnomanEmpire.Instance.World.AIDirector.Factions.Where(
                x => x.Value.IsHostile(GnomanEmpire.Instance.World.AIDirector.PlayerFaction.ID)).Select(x => x.Value);

            GnomanEmpire.Instance.EntityManager.Entities
                .Where(x => x.Value.TypeID() == (int)GameEntityType.Character)
                .Select(x => x.Value)
                .Cast<Character>()
                .Where(x => EnemyFactions.Any(y => y.ID == x.FactionID))
                .Select(x => new EnemyRow(x))
                .ToList()
                .ForEach(Enemies.Add);

            var axes = GnomanEmpire.Instance.EntityManager.Entities
                .Where(x => x.Value.TypeID() == (int)GameEntityType.Item)
                .Select(x => x.Value)
                .Cast<Item>()
                .Where(x => x.ItemID == ItemID.FellingAxe.ToString())
                .ToList();

            axes.ToList();
            itemCreator = new ItemCreator();
        }

        private void LoadGnomes()
        {
            var chars = GnomanEmpire.Instance.EntityManager.Entities
                .Where(x => x.Value.TypeID() == (int)GameEntityType.Character)
                .Select(x => x.Value)
                .Cast<Character>();

            chars.Where(x => x.RaceID == RaceID.Gnome.ToString())
                .Select(x => new GnomeRow(x))
                .ToList()
                .ForEach(gnome =>
                {
                    if (Gnomes.All(x => x.Id != gnome.Id))
                        Gnomes.Add(gnome);
                });
        }

        private void LoaderComplete(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            LoadDifficulty();
            GnomeGrid.ItemsSource = Gnomes;
            ProfessionColumn.ItemsSource = Professions;
            EnemyGrid.ItemsSource = Enemies;
            EnemyGrid.Items.Refresh();

            GameLoaded = true;
            LoadButton.IsEnabled = true;
            ProgressBar.Visibility = Visibility.Hidden;
            StatusBlock.Text = "Game save loaded";
        }

        private void LoadDifficulty()
        {
            var settings = GnomanEmpire.Instance.World.DifficultySettings;
            EnemyStrengthBox.Text = settings.EnemyStrength.ToString(CultureInfo.InvariantCulture);
            AttackRateBox.Text = settings.AttackRate.ToString(CultureInfo.InvariantCulture);
            AttackSizeBox.Text = settings.AttackSize.ToString(CultureInfo.InvariantCulture);

            IncreaseStrengthCheckBox.IsChecked = settings.IncreaseOverTime;
            BearCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.Bear.ToString());
            HoneyBadgerCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.HoneyBadger.ToString());
            MonitorLizardCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.MonitorLizard.ToString());
            GoblinCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.Goblin.ToString());
            OgreCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.Ogre.ToString());
            BlueOgreCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.BlueOgre.ToString());
            MantCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.Mant.ToString());
            GolemCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.Golem.ToString());
            ZombieCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.Zombie.ToString());
            SkeletonCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.Skeleton.ToString());
            BeetleCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.Beetle.ToString());
            BeetleCocoonCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.BeetleCocoon.ToString());
            SpiderCheckbox.IsChecked = settings.IsRaceAllowed(RaceID.Spider.ToString());
        }

        private void SaveDifficulty()
        {
            var settings = GnomanEmpire.Instance.World.DifficultySettings;

            float f;
            if (float.TryParse(EnemyStrengthBox.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out f))
            {
                settings.EnemyStrength = f;
            }
            if (float.TryParse(AttackRateBox.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out f))
            {
                settings.AttackRate = f;
            }
            if (float.TryParse(AttackSizeBox.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out f))
            {
                settings.AttackSize = f;
            }

            settings.IncreaseOverTime = IncreaseStrengthCheckBox.IsChecked == true;
            settings.AllowRace(RaceID.Bear.ToString(), BearCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.HoneyBadger.ToString(), HoneyBadgerCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.MonitorLizard.ToString(), MonitorLizardCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.Goblin.ToString(), GoblinCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.Ogre.ToString(), OgreCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.BlueOgre.ToString(), BlueOgreCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.Mant.ToString(), MantCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.Golem.ToString(), GolemCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.Zombie.ToString(), ZombieCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.Skeleton.ToString(), SkeletonCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.Beetle.ToString(), BeetleCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.BeetleCocoon.ToString(), BeetleCocoonCheckbox.IsChecked == true);
            settings.AllowRace(RaceID.Spider.ToString(), SpiderCheckbox.IsChecked == true);
        }

        private void Clear()
        {
            GameLoaded = false;
            Gnomes = new ObservableCollection<GnomeRow>();
            Professions = new List<Profession>();
            Enemies = new List<EnemyRow>();
        }

        private static void UpdateGame()
        {
            var updateMethod = typeof(GnomanEmpire).GetMethod("Update", BindingFlags.Instance | BindingFlags.NonPublic);
            updateMethod.Invoke(GnomanEmpire.Instance, new object[] { new GameTime(TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(1)) });
        }

        private void Save(object sender, ExecutedRoutedEventArgs e)
        {
            /*if (File.Directory != null)
                File.CopyTo(Path.Combine(File.Directory.FullName, Path.GetFileNameWithoutExtension(File.Name)) + ".backup", true);*/

            SaveDifficulty();

            EndGnomeEdit();
            Gnomes.ToList().ForEach(x => x.Save());
            Enemies.ForEach(x => x.Save());
            //GnomanEmpire.Instance.Camera.Update(1.0f);

            ProgressBar.Visibility = Visibility.Visible;
            var worker = new BackgroundWorker();
            worker.DoWork += SaverSave;
            worker.RunWorkerCompleted += SaverComplete;
            worker.RunWorkerAsync();
            /*if(worker.IsBusy == false)
			{
				SaveDifficulty();

				EndGnomeEdit();
				Gnomes.ToList().ForEach(x => x.Save());
				Enemies.ForEach(x => x.Save());

				ProgressBar.Visibility = Visibility.Visible;
				var worker1 = new BackgroundWorker();
				worker1.DoWork += SaverSave;
				worker1.RunWorkerCompleted += SaverComplete1;
				worker1.RunWorkerAsync();
			}*/
        }

        private void SaverSave(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            GnomanEmpire.Instance.SaveGame().Wait();
        }

        private void SaverComplete(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            ProgressBar.Visibility = Visibility.Hidden;
            AddStatusText("Save Complete.");
        }

        /*private void SaverComplete1(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
		{
			ProgressBar.Visibility = Visibility.Hidden;
			AddStatusText("Saver #2 done.");
		}*/

        private void ShowWorld(object sender, ExecutedRoutedEventArgs e)
        {
            Tab.SelectedIndex = 0;
            GnomeTools.Visibility = Visibility.Collapsed;
            EnemyTools.Visibility = Visibility.Collapsed;
        }

        private void ShowGnomes(object sender, ExecutedRoutedEventArgs e)
        {
            Tab.SelectedIndex = 1;
            GnomeTools.Visibility = Visibility.Visible;
            EnemyTools.Visibility = Visibility.Collapsed;
        }

        private void ShowEnemies(object sender, ExecutedRoutedEventArgs e)
        {
            Tab.SelectedIndex = 2;
            GnomeTools.Visibility = Visibility.Collapsed;
            EnemyTools.Visibility = Visibility.Visible;
        }

        private void SetAttributes(object sender, ExecutedRoutedEventArgs e)
        {
            EndGnomeEdit();

            var dlg = new AttributeDialog { Owner = this };
            var result = dlg.ShowDialog();
            if (result == false)
            {
                return;
            }

            int attributeValue;
            Int32.TryParse(dlg.AttributeValue.Text, out attributeValue);
            SelectedGnomeRows.ToList().ForEach(x => x.SetAttributes(attributeValue));
            GnomeGrid.Items.Refresh();
        }

        private void SetSkills(object sender, ExecutedRoutedEventArgs e)
        {
            EndGnomeEdit();

            var dlg = new SkillDialog { Owner = this };
            var result = dlg.ShowDialog();
            if (result == false)
            {
                return;
            }

            int skillValue;
            Int32.TryParse(dlg.SkillValue.Text, out skillValue);

            if (dlg.MilitarySkills.IsChecked == true)
            {
                SelectedGnomeRows.ToList().ForEach(x => x.SetMilitarySkills(skillValue));
            }

            if (dlg.ProfessionSkills.IsChecked == true)
            {
                SelectedGnomeRows.ToList().ForEach(x => x.SetProfessionSkills(skillValue));
            }
            GnomeGrid.Items.Refresh();
        }

        private void RevealMapButton_Click(object sender, RoutedEventArgs e)
        {
            var map = GnomanEmpire.Instance.Map;

            foreach (var mapCell in map.Levels.SelectMany(level => level.SelectMany(cells => cells)))
            {
                mapCell.IsVisible = true;
            }
            AddStatusText("Revealed map");
        }

        private void RevealOreButton_Click(object sender, RoutedEventArgs e)
        {
            var map = GnomanEmpire.Instance.Map;

            foreach (var mapCell in map.Levels.SelectMany(level => level.SelectMany(cells => cells)))
            {
                var mineral = mapCell.EmbeddedWall as Mineral;
                if (mineral == null)
                {
                    continue;
                }

                /*if(Int32.Parse(mineral.MaterialID) >= (int)Material.Coal && Int32.Parse(mineral.MaterialID) <= (int)Material.BlueGem)*/
                /*if(Int32.Parse(mineral.MaterialID) >= (int)Material.Coal && Int32.Parse(mineral.MaterialID) <= (int)Material.BlueGem)*/
                else
                {
                    mapCell.IsVisible = true;
                }
            }
            //map.MoveCamera(new Vector3());
            //GnomanEmpire.Instance.Camera.Update(1.0f);
            AddStatusText("Revealed ore");
        }

        private void ExpandOreButton_Click(object sender, RoutedEventArgs e)
        {
            var map = GnomanEmpire.Instance.Map;
            var em = GnomanEmpire.Instance.EntityManager;

            var mineralsToAdd = new List<Mineral>();

            for (var depth = 0; depth < map.MapDepth; depth++)
            {
                for (var height = 0; height < map.MapHeight; height++)
                {
                    for (var width = 0; width < map.MapWidth; width++)
                    {
                        var mineral = map.Levels[depth][height][width].EmbeddedWall as Mineral;
                        if (mineral == null)
                        {
                            continue;
                        }

                        if (height != 0 && !map.Levels[depth][height - 1][width].HasEmbeddedWall() && map.Levels[depth][height - 1][width].HasNaturalWall() && map.Levels[depth][height - 1][width].Wall >= 4)
                        {
                            mineralsToAdd.Add(new Mineral(new Vector3(width, height - 1, depth), mineral.MaterialID));
                        }
                        if (width != 0 && !map.Levels[depth][height][width - 1].HasEmbeddedWall() && map.Levels[depth][height][width - 1].HasNaturalWall() && map.Levels[depth][height][width - 1].Wall >= 4)
                        {
                            mineralsToAdd.Add(new Mineral(new Vector3(width - 1, height, depth), mineral.MaterialID));
                        }
                        if (height + 1 != map.MapHeight && !map.Levels[depth][height + 1][width].HasEmbeddedWall() && map.Levels[depth][height + 1][width].HasNaturalWall() && map.Levels[depth][height + 1][width].Wall >= 4)
                        {
                            mineralsToAdd.Add(new Mineral(new Vector3(width, height + 1, depth), mineral.MaterialID));
                        }
                        if (width + 1 != map.MapWidth && !map.Levels[depth][height][width + 1].HasEmbeddedWall() && map.Levels[depth][height][width + 1].HasNaturalWall() && map.Levels[depth][height][width + 1].Wall >= 4)
                        {
                            mineralsToAdd.Add(new Mineral(new Vector3(width + 1, height, depth), mineral.MaterialID));
                        }
                    }
                }
            }
            //GnomanEmpire.Instance.Camera.Update(1.0f);
            mineralsToAdd.ForEach(em.SpawnEntityImmediate);
            AddStatusText("Expanded ore");
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {

            var selectedItem = ItemList.SelectedItem as ItemRow;
            var selectedMaterial = MaterialList.SelectedItem as MaterialRow;
            int amount;
            if (!Int32.TryParse(ItemAmount.Text, out amount))
                return;

            var position = FindPosition();
            if (position == Vector3.Zero || selectedItem == null || selectedMaterial == null)
                return;

            //var qualityRow = QualityList.SelectedItem as QualityRow;

            var itemName = itemCreator.CreateItem(selectedItem, selectedMaterial, amount, position);
            AddStatusText("Added " + amount + "x " + itemName);
        }


        private void AddStatusText(string text)
        {
            StatusBlock.Text = text + "\r\n" + StatusBlock.Text;
        }

        private Vector3 FindPosition()
        {
            var depth = 0;
            var height = GnomanEmpire.Instance.Map.MapHeight / 2;
            var width = GnomanEmpire.Instance.Map.MapWidth / 2;
            var found = false;
            while (depth++ < 125)
                if (GnomanEmpire.Instance.Map.Levels[depth][height][width].HasFloor())
                {
                    found = true;
                    break;
                }
            return !found ? Vector3.Zero : new Vector3(height, width, depth);
        }

        private void HealGnomes(object sender, ExecutedRoutedEventArgs e)
        {
            var gnomeIds = SelectedGnomeRows.Select(x => x.Id).ToList();

            GnomanEmpire.Instance.EntityManager.Entities
               .Where(x => x.Value.TypeID() == (int)GameEntityType.Character && gnomeIds.Contains(x.Value.ID))
               .Select(x => x.Value)
               .Cast<Character>()
               .ToList()
               .ForEach(character =>
               {
                   character.HealDestroyedBodySection();
                   character.HealWound(new Item(new Vector3(0, 0, 0), ItemID.Bandage.ToString(), Material.Wool.ToString()));
               });
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new AboutDialog { Owner = this };
            dlg.ShowDialog();
        }

        private void CanEditGnome(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = GnomeGrid != null && GnomeGrid.SelectedItems.Count > 0;
        }

        private void CanEditEnemy(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = EnemyGrid != null && EnemyGrid.SelectedItems.Count > 0;
        }

        private void SetEnemyAttributes(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new AttributeDialog { Owner = this };
            var result = dlg.ShowDialog();
            if (result == false)
            {
                return;
            }

            int attributeValue;
            Int32.TryParse(dlg.AttributeValue.Text, out attributeValue);
            SelectedEnemyRows.ToList().ForEach(x => x.SetAttributes(attributeValue));

            EnemyGrid.Items.Refresh();
        }

        private void SetEnemySkills(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new SkillDialog { Owner = this, ProfessionSkills = { IsChecked = false, IsEnabled = false } };
            var result = dlg.ShowDialog();
            if (result == false)
            {
                return;
            }

            int skillValue;
            Int32.TryParse(dlg.SkillValue.Text, out skillValue);

            if (dlg.MilitarySkills.IsChecked == true)
            {
                SelectedEnemyRows.ToList().ForEach(x => x.SetMilitarySkills(skillValue));
            }

            EnemyGrid.Items.Refresh();
        }

        private void EnemyDropItems(object sender, ExecutedRoutedEventArgs e)
        {
            var enemyIds = SelectedEnemyRows.Select(x => x.Id).ToList();

            GnomanEmpire.Instance.EntityManager.Entities
                .Where(x => x.Value.TypeID() == (int)GameEntityType.Character && enemyIds.Contains(x.Value.ID))
                .Select(x => x.Value)
                .Cast<Character>()
                .Where(x => EnemyFactions.Any(y => y.ID == x.FactionID))
                .ToList()
                .ForEach(x =>
                {
                    x.DropEverythingEquipped();
                    x.DropItem(EquipmentType.LeftHand);
                    x.DropItem(EquipmentType.RightHand);
                });
        }

        private void IrrigateButton_Click(object sender, RoutedEventArgs e)
        {
            var underGroundFarms = GnomanEmpire.Instance.Fortress.FarmManager.Farms.Where(x => x.Underground);

            foreach (var underGroundFarm in underGroundFarms)
            {
                var level = (int)underGroundFarm.RandomPosition().Z;

                foreach (var area in underGroundFarm.Areas)
                {
                    for (var x = 0; x <= area.Width; x++) // Width and height are one less than actual size?
                        for (var y = 0; y <= area.Height; y++)
                        {
                            var posX = x + area.Location.X;
                            var posY = y + area.Location.Y;
                            var mapCell = GnomanEmpire.Instance.Map.Levels[level][posY][posX];
                            if (mapCell.Liquid == null)
                            {
                                var position = new Vector3(posX, posY, level);
                                var water = new Liquid(position, Material.Water.ToString(), 1.0f, new Vector3(0, 0, 0), false);
                                mapCell.AddLiquid(water);
                            }
                        }
                }
            }
            AddStatusText("Irrigated underground farms");
        }

        private void MaterialList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedMaterial = MaterialList.SelectedItem as MaterialRow;
            ItemList.ItemsSource = selectedMaterial != null ? selectedMaterial.GetItems() : new List<ItemRow>();
            ItemList.SelectedIndex = 0;
        }

        private void SpawnGnome(object sender, ExecutedRoutedEventArgs e)
        {
            Defs.PlayerFaction.SpawnMember(FindPosition(), Defs.GnomeDef, BehaviorType.PlayerCharacter);
            LoadGnomes();
        }

        private void EndGnomeEdit()
        {
            GnomeGrid.Items.Cast<IEditableObject>().ToList().ForEach(x => x.EndEdit());
            GnomeGrid.CommitEdit(DataGridEditingUnit.Row, true);
        }

        private void GameAvailable(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = gameloaded;
        }

        private void ProfessionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0 && GnomeGrid.SelectedItem != null)
                ((GnomeRow)GnomeGrid.SelectedItem).Profession = e.AddedItems[0] as Profession;
        }

        /// <summary>
        /// Chatmetaleux's method to fix the ghost items (experimental)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>This only fix a bug in saved games, not the cause !</remarks>
        private void FixGhostItems_Click(object sender, RoutedEventArgs e)
        {
            int cnt = 0;
            // search for crates
            var results = GnomanEmpire.Instance.Fortress.StockManager.ItemsByItemID(GameLibrary.ItemID.Crate.ToString());
            if (results != null)
            {
                foreach (var valuePair in results)
                {
                    List<Game.Item> list = valuePair.Value;
                    foreach (Game.Item item in list)
                    {
                        if (item.Claimed && item.ClaimedBy == null)
                        {
                            AddStatusText(string.Format("container claimed @{0} : {1}", item.Position.ToString(), item.Name()));
                            StorageContainer sc = (StorageContainer)item;
                            foreach (Item it in sc.ContainedResources)
                            {
                                it.FixClaimedItems();
                                AddStatusText(string.Format("fix container->{0} ", it.Name()));
                            }
                            AddStatusText("container still claimed ? " + item.Claimed.ToString());
                            cnt++;
                        }
                    }

                }
            }
            AddStatusText(string.Format("Done. {0} containers fixed.", cnt));
            cnt = 0;

            // search for piles
            for (int z = 0; z < GnomanEmpire.Instance.Map.MapHeight; z++)
            {
                for (int height = 0; height < GnomanEmpire.Instance.Map.MapHeight; ++height)
                {
                    for (int width = 0; width < GnomanEmpire.Instance.Map.MapWidth; ++width)
                    {
                        foreach (GameEntity ge in GnomanEmpire.Instance.Map.Levels[z][height][width].Objects)
                        {
                            if (ge is Game.ResourcePile)
                            {
                                ResourcePile rp = (ResourcePile)ge;
                                if (rp.Claimed)
                                {
                                    AddStatusText(string.Format("pile claimed @{0} : {1}", rp.Position.ToString(), rp.Name()));
                                    foreach (Item it in rp.ContainedResources)
                                    {
                                        it.FixClaimedItems();
                                    }
                                    cnt++;
                                }
                            }
                        }
                    }
                }
            }
            AddStatusText(string.Format("Done. {0} piles fixed.", cnt));
        }
    }


        public static class Command
        {
            public static readonly RoutedUICommand ShowWorld = new RoutedUICommand("World", "ShowWorld", typeof(MainWindow));
            public static readonly RoutedUICommand ShowGnomes = new RoutedUICommand("Gnomes", "ShowGnomes", typeof(MainWindow));
            public static readonly RoutedUICommand ShowEnemies = new RoutedUICommand("Enemies", "ShowEnemies", typeof(MainWindow));

            public static readonly RoutedUICommand SetAttributes = new RoutedUICommand("Set attributes", "SetAttributes", typeof(MainWindow));
            public static readonly RoutedUICommand SetSkills = new RoutedUICommand("Set skills", "SetSkills", typeof(MainWindow));
            public static readonly RoutedUICommand SpawnGnome = new RoutedUICommand("Spawn gnome", "SpawnGnome", typeof(MainWindow));
            public static readonly RoutedUICommand HealGnomes = new RoutedUICommand("Heal gnomes", "HealGnomes", typeof(MainWindow));

            public static readonly RoutedUICommand SetEnemyAttributes = new RoutedUICommand("Set enemy attributes", "SetEnemyAttributes", typeof(MainWindow));
            public static readonly RoutedUICommand SetEnemySkills = new RoutedUICommand("Set enemy skills", "SetEnemySkills", typeof(MainWindow));
            public static readonly RoutedUICommand EnemyDropItems = new RoutedUICommand("Drop items", "EnemyDropItems", typeof(MainWindow));
        }


    
}

