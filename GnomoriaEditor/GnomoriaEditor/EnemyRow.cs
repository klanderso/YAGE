using Game;

namespace GnomoriaEditor
{
    public class EnemyRow : CharacterRow
    {
        public EnemyRow(Character character) : base(character)
        {
            Name = character.NameAndTitle();
        }
    }
}