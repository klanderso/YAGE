using Game;
using GameLibrary;

namespace GnomoriaEditor
{
    public abstract class CharacterRow
    {
        protected Character Character;

        public uint Id { get; set; }
        public string Name { get; set; }
        public int Fitness { get; set; }
        public int Nimbleness { get; set; }
        public int Curiosity { get; set; }
        public int Focus { get; set; }
        public int Charm { get; set; }
        public int Fighting { get; set; }
        public int Brawling { get; set; }
        public int Sword { get; set; }
        public int Axe { get; set; }
        public int Hammer { get; set; }
        public int Crossbow { get; set; }
        public int Gun { get; set; }
        public int Shield { get; set; }
        public int Dodge { get; set; }
        public int Armor { get; set; }

        protected CharacterRow(Character character)
        {
            Character = character;

            Id = character.ID;

            Fitness = (int)(character.AttributeLevel(CharacterAttributeType.Fitness) * 100.0);
            Nimbleness = (int)(character.AttributeLevel(CharacterAttributeType.Nimbleness) * 100.0);
            Curiosity = (int)(character.AttributeLevel(CharacterAttributeType.Curiosity) * 100.0);
            Focus = (int)(character.AttributeLevel(CharacterAttributeType.Focus) * 100.0);
            Charm = (int)(character.AttributeLevel(CharacterAttributeType.Charm) * 100.0);

            Fighting = character.SkillLevel(CharacterSkillType.NaturalAttack.ToString());
			Brawling = character.SkillLevel(CharacterSkillType.Brawling.ToString());
			Sword = character.SkillLevel(CharacterSkillType.Sword.ToString());
			Axe = character.SkillLevel(CharacterSkillType.Axe.ToString());
			Hammer = character.SkillLevel(CharacterSkillType.Hammer.ToString());
			Crossbow = character.SkillLevel(CharacterSkillType.Crossbow.ToString());
			Gun = character.SkillLevel(CharacterSkillType.Gun.ToString());
			Shield = character.SkillLevel(CharacterSkillType.Shield.ToString());
			Dodge = character.SkillLevel(CharacterSkillType.Dodge.ToString());
			Armor = character.SkillLevel(CharacterSkillType.Armor.ToString());
        }

        public virtual void Save()
        {
            Character.SetAttributeLevel(CharacterAttributeType.Fitness, Fitness);
            Character.SetAttributeLevel(CharacterAttributeType.Nimbleness, Nimbleness);
            Character.SetAttributeLevel(CharacterAttributeType.Curiosity, Curiosity);
            Character.SetAttributeLevel(CharacterAttributeType.Focus, Focus);
            Character.SetAttributeLevel(CharacterAttributeType.Charm, Charm);

			Character.SetSkillLevel(CharacterSkillType.NaturalAttack.ToString(), Fighting);
			Character.SetSkillLevel(CharacterSkillType.Brawling.ToString(), Brawling);
			Character.SetSkillLevel(CharacterSkillType.Sword.ToString(), Sword);
			Character.SetSkillLevel(CharacterSkillType.Axe.ToString(), Axe);
			Character.SetSkillLevel(CharacterSkillType.Hammer.ToString(), Hammer);
			Character.SetSkillLevel(CharacterSkillType.Crossbow.ToString(), Crossbow);
			Character.SetSkillLevel(CharacterSkillType.Gun.ToString(), Gun);
			Character.SetSkillLevel(CharacterSkillType.Shield.ToString(), Shield);
			Character.SetSkillLevel(CharacterSkillType.Dodge.ToString(), Dodge);
			Character.SetSkillLevel(CharacterSkillType.Armor.ToString(), Armor);
        }

        public void SetMilitarySkills(int skillValue)
        {
            Fighting = skillValue;
            Brawling = skillValue;
            Sword = skillValue;
            Axe = skillValue;
            Hammer = skillValue;
            Crossbow = skillValue;
            Gun = skillValue;
            Shield = skillValue;
            Dodge = skillValue;
            Armor = skillValue;
        }

        public void SetAttributes(int attributeValue)
        {
            Fitness = attributeValue;
            Nimbleness = attributeValue;
            Curiosity = attributeValue;
            Focus = attributeValue;
            Charm = attributeValue;
        }
    }
}