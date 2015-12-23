using System.Collections.Generic;
using System.Linq;
using GameLibrary;

namespace GnomoriaEditor
{
    public class MaterialRow
    {
        public Material Material { get; set; }
        public string Name { get; set; }

        public MaterialRow(Material material)
        {
            Material = material;
            var str = material.ToString();

            switch (str)
            {
                case "StoneStart":
                    Name = "Granite";
                    break;
                case "StoneEnd":
                    Name = "Brick";
                    break;
                case "MetalStart":
                    Name = "Copper";
                    break;
                case "MetalEnd":
                    Name = "Platinum";
                    break;
                case "LeatherStart":
                    Name = "YakHide";
                    break;
                case "LeatherEnd":
                    Name = "BearHide";
                    break;
                default:
                    Name = str;
                    break;
            }
        }

        public static IEnumerable<MaterialRow> GetMaterials()
        {
            var materials = new List<MaterialRow>();
            for (var i = 0; i < (int)Material.Count; i++)
            {
                var item = (Material)i;
                var str = item.ToString();
                if (str.StartsWith("Standard") || str == "Air" || str == "Grass" || str == "Water" || str == "Brick" || str == "Lava" || str.Contains("Chitin"))
                {
                    continue;
                }

                materials.Add(new MaterialRow(item));
            }
            return materials.OrderBy(x => x.Name);
        }

        public IEnumerable<ItemRow> GetItems()
        {
            switch (Material)
            {
                case Material.AlpacaBone:
                case Material.BearBone:
                case Material.EmuBone:
                case Material.HoneyBadgerBone:
                case Material.MonitorLizardBone:
                case Material.OgreBone:
                case Material.TwoHeadedOgreBone:
                case Material.YakBone:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.Bone),
                        new ItemRow(ItemID.BoneShirt),
                        new ItemRow(ItemID.Needle)
                    };
                case Material.AlpacaFlesh:
                case Material.BearFlesh:
                case Material.EmuFlesh:
                case Material.HoneyBadgerFlesh:
                case Material.MonitorLizardFlesh:
                case Material.OgreFlesh:
                case Material.TwoHeadedOgreFlesh:
                case Material.YakFlesh:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.Meat),
                        new ItemRow(ItemID.Sausage),
                        new ItemRow(ItemID.SausageOmelette),
                        new ItemRow(ItemID.Sandwich)
                    };
                case Material.AlpacaHide:
                case Material.BearHide:
                case Material.EmuHide:
                case Material.HoneyBadgerHide:
                case Material.MonitorLizardHide:
                case Material.OgreHide:
                case Material.ToughOgreHide:
                case Material.YakHide:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.LeatherArmorPanel),
                        new ItemRow(ItemID.LeatherBoot),
                        new ItemRow(ItemID.LeatherBracer),
                        new ItemRow(ItemID.LeatherCuirass),
                        new ItemRow(ItemID.LeatherGlove),
                        new ItemRow(ItemID.LeatherGreave),
                        new ItemRow(ItemID.LeatherHelm),
                        new ItemRow(ItemID.LeatherStrap),
                        new ItemRow(ItemID.RawHide)
                    };
                case Material.AlpacaSkull:
                case Material.BearSkull:
                case Material.EmuSkull:
                case Material.HoneyBadgerSkull:
                case Material.MonitorLizardSkull:
                case Material.OgreSkull:
                case Material.TwoHeadedOgreSkull:
                case Material.YakSkull:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.Skull),
                        new ItemRow(ItemID.SkullHelmet)
                    };
                case Material.Apple:
                case Material.Grape:
                case Material.Orange:
                case Material.Strawberry:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.Fruit),
                        new ItemRow(ItemID.Seed),
                        new ItemRow(ItemID.Wine)
                    };
                case Material.AppleWood:
                case Material.OrangeWood:
                case Material.Birch:
                case Material.Oak:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.Barrel),
                        new ItemRow(ItemID.Bed),
                        new ItemRow(ItemID.BedFrame),
                        new ItemRow(ItemID.Bellows),
                        new ItemRow(ItemID.BlunderbussStock),
                        new ItemRow(ItemID.Cabinet),                  
                        new ItemRow(ItemID.Chair),
                        new ItemRow(ItemID.Clipping),
                        new ItemRow(ItemID.Crate),
                        new ItemRow(ItemID.CrossbowStock),
                        new ItemRow(ItemID.Dresser),
                        new ItemRow(ItemID.FancyBedFrame),
                        new ItemRow(ItemID.FancyBed),
                        new ItemRow(ItemID.Haft),
                        new ItemRow(ItemID.Hilt),
                        new ItemRow(ItemID.Loom),
                        new ItemRow(ItemID.Plank),
                        new ItemRow(ItemID.PistolStock),
                        new ItemRow(ItemID.RawWood),
                        new ItemRow(ItemID.Stick),
                        new ItemRow(ItemID.Table),
                        new ItemRow(ItemID.Torch),
                        new ItemRow(ItemID.TrainingDummy),
                        new ItemRow(ItemID.Wheelbarrow),
                        new ItemRow(ItemID.WoodDoor),
                        new ItemRow(ItemID.WoodenShield),
                        new ItemRow(ItemID.Workbench)
                    };
                case Material.Basalt:
                case Material.Bauxite:
                case Material.Granite:
                case Material.LapisLazuli:
                case Material.Marble:
                case Material.Sandstone:
                case Material.Serpentine:
                case Material.Obsidian:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.Block),
                        new ItemRow(ItemID.Chair),
                        new ItemRow(ItemID.Chisel),
                        new ItemRow(ItemID.Furnace),
                        new ItemRow(ItemID.Hearth),
                        new ItemRow(ItemID.Knife),
                        new ItemRow(ItemID.Mold),
                        new ItemRow(ItemID.PetRock),
                        new ItemRow(ItemID.Pillar),
                        new ItemRow(ItemID.RawStone),
                        new ItemRow(ItemID.Sawblade),
                        new ItemRow(ItemID.Statue),
                        new ItemRow(ItemID.Statuette),
                        new ItemRow(ItemID.StoneDoor),
                        new ItemRow(ItemID.StoneHammer),
                        new ItemRow(ItemID.StoneHandAxe),
                        new ItemRow(ItemID.StoneKnifeBlade),
                        new ItemRow(ItemID.StoneSword),
                        new ItemRow(ItemID.Table),
                        new ItemRow(ItemID.Trough)
                    };
                case Material.Bronze:
                case Material.Copper:
                case Material.Gold:
                case Material.Iron:
                case Material.Malachite:
                case Material.Platinum:
                case Material.RoseGold:
                case Material.Silver:
                case Material.Steel:
                case Material.Tin:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.AlarmBell),
                        new ItemRow(ItemID.Anvil),
                        new ItemRow(ItemID.ArmorPlate),
                        new ItemRow(ItemID.Axle),
                        new ItemRow(ItemID.BallPeenHammer),
                        new ItemRow(ItemID.Bar),
                        new ItemRow(ItemID.BattleAxe),
                        new ItemRow(ItemID.BattleAxeHead),
                        new ItemRow(ItemID.BladeTrap),
                        new ItemRow(ItemID.Blunderbuss),
                        new ItemRow(ItemID.BlunderbussBarrel),
                        new ItemRow(ItemID.Boot),
                        new ItemRow(ItemID.Breastplate),
                        new ItemRow(ItemID.Claymore),
                        new ItemRow(ItemID.ClaymoreBlade),
                        new ItemRow(ItemID.CommemorativeCoin),
                        new ItemRow(ItemID.Crossbow),
                        new ItemRow(ItemID.CrossbowBolt),
                        new ItemRow(ItemID.CrossbowBow),
                        new ItemRow(ItemID.CuttingWheel),
                        new ItemRow(ItemID.Cylinder),
                        new ItemRow(ItemID.FellingAxe),
                        new ItemRow(ItemID.FellingAxeHead),
                        new ItemRow(ItemID.File),
                        new ItemRow(ItemID.MechanicalWall),
                        new ItemRow(ItemID.Gauntlet),
                        new ItemRow(ItemID.Gear),
                        new ItemRow(ItemID.Gearbox),
                        new ItemRow(ItemID.GemmedNecklace),
                        new ItemRow(ItemID.GemmedRing),
                        new ItemRow(ItemID.Greave),
                        new ItemRow(ItemID.Hammer),
                        new ItemRow(ItemID.HammerHead),
                        new ItemRow(ItemID.HandAxe),
                        new ItemRow(ItemID.HandAxeHead),
                        new ItemRow(ItemID.Handcrank),
                        new ItemRow(ItemID.Hatch),
                        new ItemRow(ItemID.Helmet),
                        new ItemRow(ItemID.Lever),
                        new ItemRow(ItemID.MechanismBase),
                        new ItemRow(ItemID.MetalSliver),
                        new ItemRow(ItemID.MusketRound),
                        new ItemRow(ItemID.Necklace),
                        new ItemRow(ItemID.Pauldron),
                        new ItemRow(ItemID.Pickaxe),
                        new ItemRow(ItemID.PickaxeHead),
                        new ItemRow(ItemID.Pistol),
                        new ItemRow(ItemID.PistolBarrel),
                        new ItemRow(ItemID.PressurePlate),
                        new ItemRow(ItemID.RawOre),
                        new ItemRow(ItemID.Ring),
                        new ItemRow(ItemID.Rod),
                        new ItemRow(ItemID.Screw),
                        new ItemRow(ItemID.Shield),
                        new ItemRow(ItemID.ShieldBacking),
                        new ItemRow(ItemID.ShieldBoss),
                        new ItemRow(ItemID.Spike),
                        new ItemRow(ItemID.SpikeTrap),
                        new ItemRow(ItemID.Spring),
                        new ItemRow(ItemID.Statue),
                        new ItemRow(ItemID.Statuette),
                        new ItemRow(ItemID.Sword),
                        new ItemRow(ItemID.SwordBlade),
                        new ItemRow(ItemID.TowerShield),
                        new ItemRow(ItemID.TowerShieldBacking),
                        new ItemRow(ItemID.TrapBase),
                        new ItemRow(ItemID.Warhammer),
                        new ItemRow(ItemID.WarhammerHead),
                        new ItemRow(ItemID.Wrench)
                    };
                case Material.BlueGem:
                case Material.GreenGem:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.Gem),
                        new ItemRow(ItemID.RawGem)
                    };
                case Material.Wool:
                case Material.Cotton:
                    var list = new List<ItemRow>
                    {
                        new ItemRow(ItemID.RawCloth),
                        new ItemRow(ItemID.AmmoPouch),
                        new ItemRow(ItemID.Bag),
                        new ItemRow(ItemID.Bandage),
                        new ItemRow(ItemID.Mattress),
                        new ItemRow(ItemID.Padding),
                        new ItemRow(ItemID.String)
                    };
                    if (Material == Material.Cotton)
                    {
                        list.Add(new ItemRow(ItemID.Seed));
                    }
                    return list;
                case Material.Coal:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.RawCoal)
                    };
                case Material.Clay:
                case Material.Dirt:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.RawSoil)
                    };
                case Material.Egg:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.Egg)
                    };
                case Material.Mushroom:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.Mushroom),
                        new ItemRow(ItemID.MushroomOmelette),
                        new ItemRow(ItemID.Seed),
                    };
                case Material.Milk:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.Cheese),
                        new ItemRow(ItemID.CheeseOmelette),
                        new ItemRow(ItemID.Milk)
                    };
                case Material.Wheat:
                    return new List<ItemRow>
                    {
                        new ItemRow(ItemID.Bread),
                        new ItemRow(ItemID.Seed),
                        new ItemRow(ItemID.Straw)
                    };
                default:
                    return ItemRow.GetItems();
            }
        } 
    }
}