using System.Collections.Generic;
using System.Linq;
using Game;
using GameLibrary;
using Microsoft.Xna.Framework;

namespace GnomoriaEditor
{
    public class ItemCreator
    {
        private readonly Character creator;

        public ItemCreator()
        {
            creator = GnomanEmpire.Instance.EntityManager.Entities
                .Where(x => x.Value.TypeID() == (int) GameEntityType.Character)
                .Select(x => x.Value)
                .Cast<Character>()
				.First(x => x.RaceID == RaceID.Gnome.ToString());
        }

        public string CreateItem(ItemRow item, MaterialRow material, int amount, Vector3 position)
        {
            string name = "";

            for (var i = 0; i < amount; i++)
            {
                switch (item.ItemId)
                {
                    case ItemID.LeatherArmorPanel:
                    case ItemID.LeatherBoot:
                    case ItemID.LeatherBracer:
                    case ItemID.LeatherCuirass:
                    case ItemID.LeatherGlove:
                    case ItemID.LeatherGreave:
                    case ItemID.LeatherHelm:
                    case ItemID.LeatherStrap:
                    case ItemID.BoneShirt:
                    case ItemID.Needle:
                    case ItemID.Statuette:
                    case ItemID.Sausage:
                    case ItemID.SausageOmelette:
                    case ItemID.Sandwich:
                    case ItemID.SkullHelmet:
                    case ItemID.Wine:
                    case ItemID.Barrel:
                    case ItemID.Bed:
                    case ItemID.BedFrame:
                    case ItemID.Bellows:
                    case ItemID.Cabinet:
                    case ItemID.Chair:
                    case ItemID.Crate:
                    case ItemID.CrossbowStock:
                    case ItemID.Dresser:
                    case ItemID.FancyBedFrame:
                    case ItemID.FancyBed:
                    case ItemID.Haft:
                    case ItemID.Hilt:
                    case ItemID.Loom:
                    case ItemID.TrainingDummy:
                    case ItemID.Wheelbarrow:
                    case ItemID.WoodDoor:
                    case ItemID.WoodenShield:
                    case ItemID.Workbench:
                    case ItemID.Block:
                    case ItemID.Chisel:
                    case ItemID.Furnace:
                    case ItemID.Hearth:
                    case ItemID.Knife:
                    case ItemID.Mold:
                    case ItemID.PetRock:
                    case ItemID.Pillar:
                    case ItemID.Sawblade:
                    case ItemID.Statue:
                    case ItemID.Stick:
                    case ItemID.StoneDoor:
                    case ItemID.StoneHammer:
                    case ItemID.StoneHandAxe:
                    case ItemID.StoneKnifeBlade:
                    case ItemID.StoneSword:
                    case ItemID.Table:
                    case ItemID.Torch:
                    case ItemID.Trough:
                    case ItemID.Gem:
                    case ItemID.AmmoPouch:
                    case ItemID.Bag:
                    case ItemID.Bandage:
                    case ItemID.Mattress:
                    case ItemID.Padding:
                    case ItemID.String:
                    case ItemID.Bolt:
                    case ItemID.AlarmBell:
                    case ItemID.Anvil:
                    case ItemID.ArmorPlate:
                    case ItemID.Axle:
                    case ItemID.BallPeenHammer:
                    case ItemID.Bar:
                    case ItemID.BattleAxe:
                    case ItemID.BattleAxeHead:
                    case ItemID.BladeTrap:
                    case ItemID.Blunderbuss:
                    case ItemID.BlunderbussBarrel:
                    case ItemID.Boot:
                    case ItemID.Breastplate:
                    case ItemID.Claymore:
                    case ItemID.ClaymoreBlade:
                    case ItemID.CommemorativeCoin:
                    case ItemID.Crossbow:
                    case ItemID.CrossbowBolt:
                    case ItemID.CrossbowBow:
                    case ItemID.CuttingWheel:
                    case ItemID.Cylinder:
                    case ItemID.File:
                    case ItemID.MechanicalWall:
                    case ItemID.Gauntlet:
                    case ItemID.Gear:
                    case ItemID.Gearbox:
                    case ItemID.GemmedNecklace:
                    case ItemID.GemmedRing:
                    case ItemID.Greave:
                    case ItemID.Hammer:
                    case ItemID.HammerHead:
                    case ItemID.HandAxe:
                    case ItemID.HandAxeHead:
                    case ItemID.Handcrank:
                    case ItemID.Hatch:
                    case ItemID.Helmet:
                    case ItemID.Lever:
                    case ItemID.MechanismBase:
                    case ItemID.MetalSliver:
                    case ItemID.MusketRound:
                    case ItemID.Necklace:
                    case ItemID.Pauldron:
                    case ItemID.Pickaxe:
                    case ItemID.PickaxeHead:
                    case ItemID.Pistol:
                    case ItemID.PistolBarrel:
                    case ItemID.PressurePlate:
                    case ItemID.Ring:
                    case ItemID.Rod:
                    case ItemID.Screw:
                    case ItemID.Shield:
                    case ItemID.ShieldBacking:
                    case ItemID.ShieldBoss:
                    case ItemID.Spike:
                    case ItemID.SpikeTrap:
                    case ItemID.Spring:
                    case ItemID.Sword:
                    case ItemID.SwordBlade:
                    case ItemID.TowerShield:
                    case ItemID.TowerShieldBacking:
                    case ItemID.TrapBase:
                    case ItemID.Warhammer:
                    case ItemID.WarhammerHead:
                    case ItemID.Wrench:
                    case ItemID.Cheese:
                    case ItemID.CheeseOmelette:
                    case ItemID.MushroomOmelette:
                    case ItemID.Bread:
                    case ItemID.Plank:
                        /*var complexItem = CreateComplexItem(item.ItemId, material.Material, position);
                        name = complexItem.Name();
                        break;*/
                    case ItemID.Bone:
                    case ItemID.Clipping:
                    case ItemID.Egg:
                    case ItemID.Fruit:
                    case ItemID.Meat:
                    case ItemID.Milk:
                    case ItemID.Mushroom:
                    case ItemID.RawCloth:
                    case ItemID.RawCoal:
                    case ItemID.RawGem:
                    case ItemID.RawHide:
                    case ItemID.RawOre:
                    case ItemID.RawSoil:
                    case ItemID.RawStone:
                    case ItemID.RawWood:
                    case ItemID.Seed:
                    case ItemID.Skull:
                    case ItemID.Straw:
                    case ItemID.Wheat:
                    default:
                        var newItem = CreateSimpleItem(item.ItemId, material.Material, position);
                        GnomanEmpire.Instance.Fortress.AddItem(newItem);
                        name = newItem.Name();
                        break;
                }
            }
            return name;
        }

        private Item CreateSimpleItem(ItemID itemId, Material material, Vector3 position)
        {
            var componentSource = GetComponentSource(material, position);

			var newItem = new Item(position, itemId.ToString(), material.ToString());

            if (componentSource != null)
            {
                newItem.CrafterHistory = componentSource.Character.History;
                if (componentSource.ShouldDestroy)
                {
                    componentSource.Character.LeftRegion();
                }
            }

            GnomanEmpire.Instance.EntityManager.SpawnEntityImmediate(newItem);
            return newItem;
        }

        private Item CreateComplexItem(ItemID itemId, Material material, Vector3 position)
        {
            Item newItem;
            List<Item> components;
            if (itemId == ItemID.Bag || itemId == ItemID.Barrel ||
                itemId == ItemID.Crate || itemId == ItemID.Wheelbarrow)
            {
                components = CreateComponents(itemId, material, position);
                newItem = new StorageContainer(position, itemId.ToString(), components) {CrafterHistory = creator.History};
            }
            else
            {
                components = CreateComponents(itemId, material, position);
                if (components.Any())
                {
					newItem = new Item(position, itemId.ToString(), components) { CrafterHistory = creator.History };
                }
                else
                {
					newItem = new Item(position, itemId.ToString(), material.ToString());
                }
            }
			
            GnomanEmpire.Instance.EntityManager.SpawnEntityImmediate(newItem);
            GnomanEmpire.Instance.Fortress.AddItem(newItem);

            RemoveComponents(components);
            
            return newItem;
        }

        private ComponentSource GetComponentSource(Material material, Vector3 position)
        {
            var componentSource = new ComponentSource();
            var characters = GnomanEmpire.Instance.EntityManager.Entities.Where(x => x.Value.TypeID() == (int) GameEntityType.Character).Select(x => x.Value).Cast<Character>();
            switch (material)
            {
                case Material.AlpacaHide:
                case Material.AlpacaBone:
                case Material.AlpacaFlesh:
                case Material.AlpacaSkull:
					var alpaca = characters.FirstOrDefault(x => x.RaceID.ToString() == RaceID.Alpaca.ToString());
                    if (alpaca == null)
                    {
                        componentSource.Character = Defs.NeutralFaction.SpawnMember(position, Defs.AlpacaDef);
                        componentSource.ShouldDestroy = true;
                    }
                    else
                    {
                        componentSource.Character = alpaca;
                    }
                    break;
                case Material.BearHide:
                case Material.BearBone:
                case Material.BearFlesh:
                case Material.BearSkull:
					var bear = characters.FirstOrDefault(x => x.RaceID.ToString() == RaceID.Bear.ToString());
                    if (bear == null)
                    {
                        componentSource.Character = Defs.WildFaction.SpawnMember(position, Defs.BearDef);
                        componentSource.ShouldDestroy = true;
                    }
                    else
                    {
                        componentSource.Character = bear;
                    }
                    break;
                case Material.EmuHide:
                case Material.EmuBone:
                case Material.EmuFlesh:
                case Material.EmuSkull:
                case Material.Egg:
					var emu = characters.FirstOrDefault(x => x.RaceID.ToString() == RaceID.Emu.ToString());
                    if (emu == null)
                    {
                        componentSource.Character = Defs.NeutralFaction.SpawnMember(position, Defs.EmuDef);
                        componentSource.ShouldDestroy = true;
                    }
                    else
                    {
                        componentSource.Character = emu;
                    }
                    
                    break;
                case Material.HoneyBadgerHide:
                case Material.HoneyBadgerBone:
                case Material.HoneyBadgerFlesh:
                case Material.HoneyBadgerSkull:
					var badger = characters.FirstOrDefault(x => x.RaceID.ToString() == RaceID.HoneyBadger.ToString());
                    if (badger == null)
                    {
                        componentSource.Character = Defs.WildFaction.SpawnMember(position, Defs.HoneyBadgerDef);
                        componentSource.ShouldDestroy = true;
                    }
                    else
                    {
                        componentSource.Character = badger;
                    }
                    break;
                case Material.MonitorLizardHide:
                case Material.MonitorLizardBone:
                case Material.MonitorLizardFlesh:
                case Material.MonitorLizardSkull:
					var lizard = characters.FirstOrDefault(x => x.RaceID.ToString() == RaceID.MonitorLizard.ToString());
                    if (lizard == null)
                    {
                        componentSource.Character = Defs.WildFaction.SpawnMember(position, Defs.MonitorLizardDef);
                        componentSource.ShouldDestroy = true;
                    }
                    else
                    {
                        componentSource.Character = lizard;
                    }
                    break;
                case Material.OgreHide:
                case Material.OgreBone:
                case Material.OgreFlesh:
                case Material.OgreSkull:
					var ogre = characters.FirstOrDefault(x => x.RaceID.ToString() == RaceID.Ogre.ToString());
                    if (ogre == null)
                    {
                        componentSource.Character = Defs.EnemyFaction.SpawnMember(position, Defs.OgreDef);
                        componentSource.ShouldDestroy = true;
                    }
                    else
                    {
                        componentSource.Character = ogre;
                    }
                    break;
                case Material.ToughOgreHide:
					var toughogre = characters.FirstOrDefault(x => x.RaceID.ToString() == RaceID.BlueOgre.ToString());
                    if (toughogre == null)
                    {
                        componentSource.Character = Defs.EnemyFaction.SpawnMember(position, Defs.ToughOgreDef);
                        componentSource.ShouldDestroy = true;
                    }
                    else
                    {
                        componentSource.Character = toughogre;
                    }
                    break;
                case Material.YakHide:
                case Material.YakBone:
                case Material.YakFlesh:
                case Material.YakSkull:
                case Material.Milk:
					var yak = characters.FirstOrDefault(x => x.RaceID.ToString() == RaceID.Yak.ToString());
                    if (yak == null)
                    {
                        componentSource.Character = Defs.NeutralFaction.SpawnMember(position, Defs.YakDef);
                        componentSource.ShouldDestroy = true;
                    }
                    else
                    {
                        componentSource.Character = yak;
                    }
                    break;
                default:
                    return null;
            }
            return componentSource;
        }

        private List<Item> CreateComponents(ItemID itemId, Material material, Vector3 position)
        {
            var components = new List<Item>();
            var subComponents = new List<Item>();
            var subComponents2 = new List<Item>();

            var componentSource = GetComponentSource(material, position);

            switch (itemId)
            {
                case ItemID.Plank:
					components.Add(new Item(position, ItemID.RawWood.ToString(), material.ToString()));
                    break;
                case ItemID.Stick:
                    subComponents = CreateComponents(ItemID.Plank, material, position);
					components.Add(new Item(position, ItemID.Plank.ToString(), subComponents));
                    break;
                case ItemID.Bed:
                    subComponents = CreateComponents(ItemID.BedFrame, material, position);
                    subComponents2 = CreateComponents(ItemID.Mattress, material, position);
					components.Add(new Item(position, ItemID.BedFrame.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Mattress.ToString(), subComponents2));
                    break;
                case ItemID.FancyBed:
                    subComponents = CreateComponents(ItemID.FancyBedFrame, material, position);
                    subComponents2 = CreateComponents(ItemID.Mattress, material, position);
					components.Add(new Item(position, ItemID.FancyBedFrame.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Mattress.ToString(), subComponents2));
                    break;
                case ItemID.Bellows:
                case ItemID.CrossbowStock:
                case ItemID.Loom:
                case ItemID.TrainingDummy:
                case ItemID.Wheelbarrow:
                case ItemID.Barrel:
                case ItemID.BedFrame:
                case ItemID.Crate:
                case ItemID.FancyBedFrame:
                case ItemID.WoodDoor:
                case ItemID.WoodenShield:
                    subComponents = CreateComponents(ItemID.Plank, material, position);
                    for(var i = 0; i < 4; i++)
						components.Add(new Item(position, ItemID.Plank.ToString(), subComponents));
                    break;
                case ItemID.Dresser:
                case ItemID.Cabinet:
                case ItemID.Workbench:
                    subComponents = CreateComponents(ItemID.Plank, material, position);
                    for(var i = 0; i < 6; i++)
						components.Add(new Item(position, ItemID.Plank.ToString(), subComponents));
                    break;
                case ItemID.Torch:
                    subComponents = CreateComponents(ItemID.Stick, material, position);
					components.Add(new Item(position, ItemID.Stick.ToString(), subComponents));
					components.Add(new Item(position, ItemID.RawCoal.ToString(), Material.Coal.ToString()));
                    break;
                case ItemID.Haft:
                case ItemID.Hilt:
                    subComponents = CreateComponents(ItemID.Stick, material, position);
					components.Add(new Item(position, ItemID.Stick.ToString(), subComponents));
                    break;
                case ItemID.Block:
					components.Add(new Item(position, ItemID.RawStone.ToString(), material.ToString()));
                    break;
                case ItemID.Chisel:
                case ItemID.Furnace:
                case ItemID.Hearth:
                case ItemID.Knife:
                case ItemID.Mold:
                case ItemID.PetRock:
                case ItemID.Sawblade:
                case ItemID.StoneDoor:
                case ItemID.StoneHammer:
                case ItemID.StoneHandAxe:
                case ItemID.StoneKnifeBlade:
                case ItemID.StoneSword:
                case ItemID.Trough:
                    subComponents = CreateComponents(ItemID.Block, material, position);
					components.Add(new Item(position, ItemID.Block.ToString(), subComponents));
                    break;
                case ItemID.Pillar:
                    subComponents = CreateComponents(ItemID.Block, material, position);
                    for (var i = 0; i < 4; i++)
						components.Add(new Item(position, ItemID.Block.ToString(), subComponents));
                    break;
                case ItemID.Statue:
                    subComponents = CreateComponents(IsStone(material) ? ItemID.Block : ItemID.Bar, material, position);
                    for (var i = 0; i < 4; i++)
                        components.Add(NewItem(position, IsStone(material) ? ItemID.Block : ItemID.Bar, material, subComponents));
                    break;
                case ItemID.Statuette:
                    subComponents = CreateComponents(IsStone(material) ? ItemID.Block : ItemID.Bar, material, position);
                    components.Add(NewItem(position, IsStone(material) ? ItemID.Block : ItemID.Bar, material, subComponents));
                    break;
                case ItemID.Chair:
                case ItemID.Table:
                    subComponents = CreateComponents(IsWood(material) ? ItemID.Plank : ItemID.Block, material, position);
                    for(var i = 0; i < 4; i++)
						components.Add(new Item(position, IsWood(material) ? ItemID.Plank.ToString() : ItemID.Block.ToString(), subComponents));
                    break;
                case ItemID.BoneShirt:
                case ItemID.Needle:
					components.Add(new Item(position, ItemID.Bone.ToString(), material.ToString()) { CrafterHistory = componentSource != null ? componentSource.Character.History : null });
                    break;
                case ItemID.Sausage:
					components.Add(new Item(position, ItemID.Meat.ToString(), material.ToString()) { CrafterHistory = componentSource != null ? componentSource.Character.History : null });
                    break;
                case ItemID.SausageOmelette:
                    subComponents = CreateComponents(ItemID.Sausage, material, position);
                    subComponents2 = CreateComponents(ItemID.Cheese, Material.Milk, position);
					components.Add(new Item(position, ItemID.Sausage.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Cheese.ToString(), subComponents2));
					components.Add(new Item(position, ItemID.Egg.ToString(), Material.Egg.ToString()) { CrafterHistory = GetComponentSource(Material.Egg, position).Character.History });
                    break;
                case ItemID.Sandwich:
                    subComponents = CreateComponents(ItemID.Sausage, material, position);
                    subComponents2 = CreateComponents(ItemID.Bread, Material.Wheat, position);
					components.Add(new Item(position, ItemID.Sausage.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Bread.ToString(), subComponents2));
                    break;
                case ItemID.SkullHelmet:
					components.Add(new Item(position, ItemID.Skull.ToString(), material.ToString()) { CrafterHistory = componentSource != null ? componentSource.Character.History : null });
                    break;
                case ItemID.Wine:
					components.Add(new Item(position, ItemID.Fruit.ToString(), material.ToString()));
                    break;
                case ItemID.LeatherBoot:
                case ItemID.LeatherBracer:
                case ItemID.LeatherCuirass:
                case ItemID.LeatherGlove:
                case ItemID.LeatherGreave:
                case ItemID.LeatherHelm:
                    subComponents = CreateComponents(ItemID.LeatherArmorPanel, material, position);
                    subComponents2 = CreateComponents(ItemID.Padding, Material.Wool, position);
					components.Add(new Item(position, ItemID.LeatherArmorPanel.ToString(), subComponents));
					components.Add(new Item(position, ItemID.LeatherArmorPanel.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Padding.ToString(), subComponents2));
                    break;
                case ItemID.LeatherArmorPanel:
                case ItemID.LeatherStrap:
					components.Add(new Item(position, ItemID.RawHide.ToString(), material.ToString()) { CrafterHistory = componentSource != null ? componentSource.Character.History : null });
                    break;
                case ItemID.Gem:
					components.Add(new Item(position, ItemID.RawGem.ToString(), material.ToString()));
                    break;
                case ItemID.AmmoPouch:
                case ItemID.Bag:
                case ItemID.Bandage:
                case ItemID.Mattress:
                case ItemID.Padding:
                case ItemID.String:
                    subComponents = CreateComponents(ItemID.Bolt, material, position);
					components.Add(new Item(position, ItemID.Bolt.ToString(), subComponents));
                    break;
                case ItemID.Bolt:
					components.Add(new Item(position, ItemID.RawCloth.ToString(), material.ToString()));
                    break;
                case ItemID.Bar:
                    if (material == Material.Copper || material == Material.Tin || material == Material.Malachite || material == Material.Lead || material == Material.Iron || material == Material.Silver || material == Material.Gold ||
                        material == Material.Platinum)
                    {
						components.Add(new Item(position, ItemID.RawOre.ToString(), material.ToString()));
						components.Add(new Item(position, ItemID.RawOre.ToString(), material.ToString()));
						components.Add(new Item(position, ItemID.RawCoal.ToString(), Material.Coal.ToString()));
                    }
                    break;
                case ItemID.Breastplate:
                    subComponents = CreateComponents(ItemID.ArmorPlate, material, position);
                    subComponents2 = CreateComponents(ItemID.Padding, Material.Wool, position);
					components.Add(new Item(position, ItemID.ArmorPlate.ToString(), subComponents));
					components.Add(new Item(position, ItemID.ArmorPlate.ToString(), subComponents));
					components.Add(new Item(position, ItemID.ArmorPlate.ToString(), subComponents));
					components.Add(new Item(position, ItemID.ArmorPlate.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Padding.ToString(), subComponents2));
					components.Add(new Item(position, ItemID.Padding.ToString(), subComponents2));
                    break;
                case ItemID.Boot:
                case ItemID.Gauntlet:
                case ItemID.Greave:
                case ItemID.Helmet:
                case ItemID.Pauldron:
                    subComponents = CreateComponents(ItemID.ArmorPlate, material, position);
                    subComponents2 = CreateComponents(ItemID.Padding, Material.Wool, position);
					components.Add(new Item(position, ItemID.ArmorPlate.ToString(), subComponents));
					components.Add(new Item(position, ItemID.ArmorPlate.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Padding.ToString(), subComponents2));
                    break;
                case ItemID.BattleAxe:
                    subComponents = CreateComponents(ItemID.BattleAxeHead, material, position);
                    subComponents2 = CreateComponents(ItemID.Haft, Material.Oak, position);
					components.Add(new Item(position, ItemID.BattleAxeHead.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Haft.ToString(), subComponents2));
                    break;
                case ItemID.FellingAxe:
                    subComponents = CreateComponents(ItemID.FellingAxeHead, material, position);
                    subComponents2 = CreateComponents(ItemID.Haft, Material.Oak, position);
					components.Add(new Item(position, ItemID.FellingAxeHead.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Haft.ToString(), subComponents2));
                    break;
                case ItemID.Claymore:
                    subComponents = CreateComponents(ItemID.ClaymoreBlade, material, position);
                    subComponents2 = CreateComponents(ItemID.Hilt, Material.Oak, position);
					components.Add(new Item(position, ItemID.ClaymoreBlade.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Hilt.ToString(), subComponents2));
                    break;
                case ItemID.Hammer:
                    subComponents = CreateComponents(ItemID.HammerHead, material, position);
                    subComponents2 = CreateComponents(ItemID.Haft, Material.Oak, position);
					components.Add(new Item(position, ItemID.HammerHead.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Haft.ToString(), subComponents2));
                    break;
                case ItemID.HandAxe:
                    subComponents = CreateComponents(ItemID.HandAxeHead, material, position);
                    subComponents2 = CreateComponents(ItemID.Haft, Material.Oak, position);
					components.Add(new Item(position, ItemID.HandAxeHead.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Haft.ToString(), subComponents2));
                    break;
                case ItemID.AlarmBell:
                case ItemID.Anvil:
                case ItemID.ArmorPlate:
                case ItemID.Axle:
                case ItemID.BallPeenHammer:
                case ItemID.BladeTrap:
                case ItemID.Blunderbuss:
                case ItemID.BlunderbussBarrel:
                case ItemID.CommemorativeCoin:
                case ItemID.Crossbow:
                case ItemID.CrossbowBolt:
                case ItemID.CrossbowBow:
                case ItemID.CuttingWheel:
                case ItemID.Cylinder:
                case ItemID.File:
                case ItemID.MechanicalWall:
                case ItemID.Gear:
                case ItemID.Gearbox:
                case ItemID.GemmedNecklace:
                case ItemID.GemmedRing:
                case ItemID.Handcrank:
                case ItemID.Hatch:
                case ItemID.Lever:
                case ItemID.MechanismBase:
                case ItemID.MetalSliver:
                case ItemID.MusketRound:
                case ItemID.Necklace:
                case ItemID.PickaxeHead:
                case ItemID.Pistol:
                case ItemID.PistolBarrel:
                case ItemID.PressurePlate:
                case ItemID.Ring:
                case ItemID.Rod:
                case ItemID.Screw:
                case ItemID.TrapBase:
                case ItemID.Wrench:
                case ItemID.FellingAxeHead:
                    subComponents = CreateComponents(ItemID.Bar, material, position);
                    components.Add(NewItem(position, ItemID.Bar, material, subComponents));
                    components.Add(NewItem(position, ItemID.Bar, material, subComponents));
                    break;
                case ItemID.Shield:
                    subComponents = CreateComponents(ItemID.ShieldBacking, material, position);
                    subComponents2 = CreateComponents(ItemID.ShieldBoss, material, position);
					components.Add(new Item(position, ItemID.ShieldBacking.ToString(), subComponents));
					components.Add(new Item(position, ItemID.ShieldBoss.ToString(), subComponents2));
                    break;
                case ItemID.ShieldBacking:
                case ItemID.ShieldBoss:
                case ItemID.Spike:
                case ItemID.SpikeTrap:
                case ItemID.Spring:
                case ItemID.Sword:
                    subComponents = CreateComponents(ItemID.SwordBlade, material, position);
                    subComponents2 = CreateComponents(ItemID.Hilt, Material.Oak, position);
					components.Add(new Item(position, ItemID.SwordBlade.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Hilt.ToString(), subComponents2));
                    break;
                case ItemID.TowerShield:
                    subComponents = CreateComponents(ItemID.TowerShieldBacking, material, position);
                    subComponents2 = CreateComponents(ItemID.ShieldBoss, material, position);
					components.Add(new Item(position, ItemID.TowerShieldBacking.ToString(), subComponents));
					components.Add(new Item(position, ItemID.ShieldBoss.ToString(), subComponents2));
                    break;
                case ItemID.Warhammer:
                    subComponents = CreateComponents(ItemID.WarhammerHead, material, position);
                    subComponents2 = CreateComponents(ItemID.Haft, Material.Oak, position);
					components.Add(new Item(position, ItemID.WarhammerHead.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Haft.ToString(), subComponents2));
                    break;
                case ItemID.TowerShieldBacking:
                case ItemID.HammerHead:
                case ItemID.HandAxeHead:
                case ItemID.ClaymoreBlade:
                case ItemID.SwordBlade:
                case ItemID.WarhammerHead:
                case ItemID.BattleAxeHead:
                    subComponents = CreateComponents(ItemID.Bar, material, position);
                    for(var i = 0; i < 6; i++)
                        components.Add(NewItem(position, ItemID.Bar, material, subComponents));
                    break;
                case ItemID.Pickaxe:
                    subComponents = CreateComponents(ItemID.PickaxeHead, material, position);
                    subComponents2 = CreateComponents(ItemID.Haft, Material.Oak, position);
					components.Add(new Item(position, ItemID.PickaxeHead.ToString(), subComponents));
					components.Add(new Item(position, ItemID.Haft.ToString(), subComponents2));
                    break;
                case ItemID.MushroomOmelette:
                    subComponents = CreateComponents(ItemID.Cheese, Material.Milk, position);
					components.Add(new Item(position, ItemID.Mushroom.ToString(), material.ToString()));
                    components.Add(new Item(position, ItemID.Cheese.ToString(), subComponents));
                    components.Add(new Item(position, ItemID.Egg.ToString(), Material.Egg.ToString()) {CrafterHistory = GetComponentSource(Material.Egg, position).Character.History});
                    break;
                case ItemID.Cheese:
					components.Add(new Item(position, ItemID.Milk.ToString(), material.ToString()) { CrafterHistory = componentSource != null ? componentSource.Character.History : null });
                    break;
                case ItemID.CheeseOmelette:
                    subComponents = CreateComponents(ItemID.Cheese, material, position);
                    components.Add(new Item(position, ItemID.Cheese.ToString(), subComponents));
                    components.Add(new Item(position, ItemID.Egg.ToString(), Material.Egg.ToString()) { CrafterHistory = GetComponentSource(Material.Egg, position).Character.History });
                    break;
                case ItemID.Bread:
					components.Add(new Item(position, ItemID.Wheat.ToString(), material.ToString()));
                    break;
                default:
                    return new List<Item>();
            }

            if (componentSource != null && componentSource.ShouldDestroy)
            {
                componentSource.Character.LeftRegion();
            }

            components.ForEach(component => GnomanEmpire.Instance.EntityManager.SpawnEntityImmediate(component));
            
            RemoveComponents(subComponents);
            RemoveComponents(subComponents2);

            return components;
        }

        private Item NewItem(Vector3 position, ItemID itemId, Material material, List<Item> components)
        {
            return components.Any()
				? new Item(position, itemId.ToString(), components)
				: new Item(position, itemId.ToString(), material.ToString());
        }

        private bool IsWood(Material material)
        {
            return material == Material.AppleWood || material == Material.OrangeWood || material == Material.Birch || material == Material.Oak;
        }

        private bool IsStone(Material material)
        {
            return material == Material.Basalt || material == Material.Bauxite || material == Material.Granite || material == Material.LapisLazuli || material == Material.Marble || material == Material.Sandstone || material == Material.Serpentine ||
                   material == Material.Obsidian;
        }

        private void RemoveComponents(IEnumerable<Item> components)
        {
            foreach (var component in components)
            {
                var cell = GnomanEmpire.Instance.Map.GetCell(component.Position);
                cell.RemoveObject(component);
                GnomanEmpire.Instance.Fortress.RemoveItem(component);
            }
        }


    }
}