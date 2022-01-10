using System.Collections.Generic;
using UserInterface.Models;

namespace BusinessLogic.FightLogic
{
    public class FightResult
    {
        public bool IsUserWon { get; set; }
        public List<CharactersActions> ActionsList { get; set; } = new();
    }
}