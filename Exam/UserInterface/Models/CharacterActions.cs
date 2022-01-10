using BusinessLogic.FightLogic;

namespace UserInterface.Models
{
    public class CharactersActions
    {
        public string CharacterName { get; set; }
        public int d20RollResult { get; set; }
        public int Damage { get; set; }
        public HitType TypeOfHit { get; set; }
    }
}