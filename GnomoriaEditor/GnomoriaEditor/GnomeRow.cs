using System.ComponentModel;
using Game;
using GameLibrary;

namespace GnomoriaEditor
{
    public class GnomeRow : CharacterRow, IEditableObject
    {
        public Profession Profession { get; set; }

        public int Mining { get; set; }
        public int Masonry { get; set; }
        public int Stonecarving { get; set; }
        public int WoodCutting { get; set; }
        public int Carpentry { get; set; }
        public int Woodcarving { get; set; }
        public int Smelting { get; set; }
        public int Blacksmithing { get; set; }
        public int Metalworking { get; set; }
        public int WeaponCrafting { get; set; }
        public int ArmorCrafting { get; set; }
        public int Gemcutting { get; set; }
        public int JewelryMaking { get; set; }
        public int Weaving { get; set; }
        public int Tailoring { get; set; }
        public int Pottery { get; set; }
        public int Leatherworking { get; set; }
        public int Bonecarving { get; set; }
        public int Prospecting { get; set; }
        public int Tinkering { get; set; }
        public int Machining { get; set; }
        public int Engineering { get; set; }
        public int Mechanic { get; set; }
        public int AnimalHusbandry { get; set; }
        public int Butchery { get; set; }
        public int Horticulture { get; set; }
        public int Farming { get; set; }
        public int Cooking { get; set; }
        public int Brewing { get; set; }
        public int Medic { get; set; }
        public int Caretaking { get; set; }
        public int Construction { get; set; }
        public int Hauling { get; set; }

        public GnomeRow(Character character) : base(character)
        {
            Name = character.Name();
            Profession = character.Mind.Profession;

			Mining = character.SkillLevel(CharacterSkillType.Mining.ToString());
			Masonry = character.SkillLevel(CharacterSkillType.Masonry.ToString());
			Stonecarving = character.SkillLevel(CharacterSkillType.Stonecarving.ToString());
			WoodCutting = character.SkillLevel(CharacterSkillType.Woodcutting.ToString());
			Carpentry = character.SkillLevel(CharacterSkillType.Carpentry.ToString());
			Woodcarving = character.SkillLevel(CharacterSkillType.Woodcarving.ToString());
			Smelting = character.SkillLevel(CharacterSkillType.Smelting.ToString());
			Blacksmithing = character.SkillLevel(CharacterSkillType.Blacksmithing.ToString());
			Metalworking = character.SkillLevel(CharacterSkillType.Metalworking.ToString());
			WeaponCrafting = character.SkillLevel(CharacterSkillType.WeaponCrafting.ToString());
			ArmorCrafting = character.SkillLevel(CharacterSkillType.ArmorCrafting.ToString());
			Gemcutting = character.SkillLevel(CharacterSkillType.Gemcutting.ToString());
			JewelryMaking = character.SkillLevel(CharacterSkillType.JewelryMaking.ToString());
			Weaving = character.SkillLevel(CharacterSkillType.Weaving.ToString());
			Tailoring = character.SkillLevel(CharacterSkillType.Tailoring.ToString());
			Pottery = character.SkillLevel(CharacterSkillType.Pottery.ToString());
			Leatherworking = character.SkillLevel(CharacterSkillType.Leatherworking.ToString());
			Bonecarving = character.SkillLevel(CharacterSkillType.Bonecarving.ToString());
			Prospecting = character.SkillLevel(CharacterSkillType.Prospecting.ToString());
			Tinkering = character.SkillLevel(CharacterSkillType.Tinkering.ToString());
			Machining = character.SkillLevel(CharacterSkillType.Machining.ToString());
			Engineering = character.SkillLevel(CharacterSkillType.Engineering.ToString());
			Mechanic = character.SkillLevel(CharacterSkillType.Mechanic.ToString());
			AnimalHusbandry = character.SkillLevel(CharacterSkillType.AnimalHusbandry.ToString());
			Butchery = character.SkillLevel(CharacterSkillType.Butchery.ToString());
			Horticulture = character.SkillLevel(CharacterSkillType.Horticulture.ToString());
			Farming = character.SkillLevel(CharacterSkillType.Farming.ToString());
			Cooking = character.SkillLevel(CharacterSkillType.Cooking.ToString());
			Brewing = character.SkillLevel(CharacterSkillType.Brewing.ToString());
			Medic = character.SkillLevel(CharacterSkillType.Medic.ToString());
			Caretaking = character.SkillLevel(CharacterSkillType.Caretaking.ToString());
			Construction = character.SkillLevel(CharacterSkillType.Construction.ToString());
			Hauling = character.SkillLevel(CharacterSkillType.Hauling.ToString());
        }

        public override void Save()
        {
            base.Save();

            Character.SetName(Name);
            Character.Mind.Profession = Profession;

			Character.SetSkillLevel(CharacterSkillType.Mining.ToString(), Mining);
			Character.SetSkillLevel(CharacterSkillType.Masonry.ToString(), Masonry);
			Character.SetSkillLevel(CharacterSkillType.Stonecarving.ToString(), Stonecarving);
			Character.SetSkillLevel(CharacterSkillType.Woodcutting.ToString(), WoodCutting);
			Character.SetSkillLevel(CharacterSkillType.Carpentry.ToString(), Carpentry);
			Character.SetSkillLevel(CharacterSkillType.Woodcarving.ToString(), Woodcarving);
			Character.SetSkillLevel(CharacterSkillType.Smelting.ToString(), Smelting);
			Character.SetSkillLevel(CharacterSkillType.Blacksmithing.ToString(), Blacksmithing);
			Character.SetSkillLevel(CharacterSkillType.Metalworking.ToString(), Metalworking);
			Character.SetSkillLevel(CharacterSkillType.WeaponCrafting.ToString(), WeaponCrafting);
			Character.SetSkillLevel(CharacterSkillType.ArmorCrafting.ToString(), ArmorCrafting);
			Character.SetSkillLevel(CharacterSkillType.Gemcutting.ToString(), Gemcutting);
			Character.SetSkillLevel(CharacterSkillType.JewelryMaking.ToString(), JewelryMaking);
			Character.SetSkillLevel(CharacterSkillType.Weaving.ToString(), Weaving);
			Character.SetSkillLevel(CharacterSkillType.Tailoring.ToString(), Tailoring);
			Character.SetSkillLevel(CharacterSkillType.Pottery.ToString(), Pottery);
			Character.SetSkillLevel(CharacterSkillType.Leatherworking.ToString(), Leatherworking);
			Character.SetSkillLevel(CharacterSkillType.Bonecarving.ToString(), Bonecarving);
			Character.SetSkillLevel(CharacterSkillType.Prospecting.ToString(), Prospecting);
			Character.SetSkillLevel(CharacterSkillType.Tinkering.ToString(), Tinkering);
			Character.SetSkillLevel(CharacterSkillType.Machining.ToString(), Machining);
			Character.SetSkillLevel(CharacterSkillType.Engineering.ToString(), Engineering);
			Character.SetSkillLevel(CharacterSkillType.Mechanic.ToString(), Mechanic);
			Character.SetSkillLevel(CharacterSkillType.AnimalHusbandry.ToString(), AnimalHusbandry);
			Character.SetSkillLevel(CharacterSkillType.Butchery.ToString(), Butchery);
			Character.SetSkillLevel(CharacterSkillType.Horticulture.ToString(), Horticulture);
			Character.SetSkillLevel(CharacterSkillType.Farming.ToString(), Farming);
			Character.SetSkillLevel(CharacterSkillType.Cooking.ToString(), Cooking);
			Character.SetSkillLevel(CharacterSkillType.Brewing.ToString(), Brewing);
			Character.SetSkillLevel(CharacterSkillType.Medic.ToString(), Medic);
			Character.SetSkillLevel(CharacterSkillType.Caretaking.ToString(), Caretaking);
			Character.SetSkillLevel(CharacterSkillType.Construction.ToString(), Construction);
			Character.SetSkillLevel(CharacterSkillType.Hauling.ToString(), Hauling);
        }

        public void SetProfessionSkills(int skillValue)
        {
            Mining = skillValue;
            Masonry = skillValue;
            Stonecarving = skillValue;
            WoodCutting = skillValue;
            Carpentry = skillValue;
            Woodcarving = skillValue;
            Smelting = skillValue;
            Blacksmithing = skillValue;
            Metalworking = skillValue;
            WeaponCrafting = skillValue;
            ArmorCrafting = skillValue;
            Gemcutting = skillValue;
            JewelryMaking = skillValue;
            Weaving = skillValue;
            Tailoring = skillValue;
            Pottery = skillValue;
            Leatherworking = skillValue;
            Bonecarving = skillValue;
            Prospecting = skillValue;
            Tinkering = skillValue;
            Machining = skillValue;
            Engineering = skillValue;
            Mechanic = skillValue;
            AnimalHusbandry = skillValue;
            Butchery = skillValue;
            Horticulture = skillValue;
            Farming = skillValue;
            Cooking = skillValue;
            Brewing = skillValue;
            Medic = skillValue;
            Caretaking = skillValue;
            Construction = skillValue;
            Hauling = skillValue;
        }

        public void BeginEdit()
        {
        }

        public void EndEdit()
        {
            Save();
        }

        public void CancelEdit()
        {
        }
    }
}