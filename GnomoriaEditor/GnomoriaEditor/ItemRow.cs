using System.Collections.Generic;
using System.Linq;
using GameLibrary;

namespace GnomoriaEditor
{
    public class ItemRow
    {
        public ItemID ItemId { get; set; }
        public string Name { get; set; }

        public ItemRow(ItemID id)
        {
            ItemId = id;
            var str = id.ToString();

            switch (str)
            {
                case "RawStart":
                    Name = "RawSoil";
                    break;
                case "RawEnd":
                    Name = "RawHide";
                    break;
                case "FoodStart":
                    Name = "Fruit";
                    break;
                case "FoodEnd":
                    Name = "Sandwich";
                    break;
                case "DrinkStart":
                    Name = "Milk";
                    break;
                case "DrinkEnd":
                    Name = "Beer";
                    break;
                case "StorageStart":
                    Name = "Crate";
                    break;
                case "StorageEnd":
                    Name = "Bag";
                    break;
                case "FurnitureStart":
                    Name = "WoodDoor";
                    break;
                case "FurnitureEnd":
                    Name = "Statue";
                    break;
                case "WeaponStart":
                    Name = "Sword";
                    break;
                case "WeaponEnd":
                    Name = "Torch";
                    break;
                case "EquipmentStart":
                    Name = "Helmet";
                    break;
                case "EquipmentEnd":
                    Name = "LeatherBoot";
                    break;
                case "ToolStart":
                    Name = "Pickaxe";
                    break;
                case "ToolEnd":
                    Name = "FellingAxe";
                    break;
                default:
                    Name = str;
                    break;
            }
        }

        public static IEnumerable<ItemRow> GetItems()
        {
            var items = new List<ItemRow>();
            for (var i = 0; i < (int)ItemID.Count; i++)
            {
                var item = (ItemID) i;
                items.Add(new ItemRow(item));
            }
            return items.OrderBy(x => x.Name);
        }
    }
}