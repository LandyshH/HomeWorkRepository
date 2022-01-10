using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Characters;
using BusinessLogic.Models;

namespace BusinessLogic.FightLogic
{
    public class Fight
    {
        public Winner Winner { get; set; }
        public List<CharactersActions> FightProcess(Opponents opponents)
        {
            var ActionsList = new List<CharactersActions>();
            while (opponents.User.HitPoints > 0 && opponents.Monster.HitPoints > 0)
            {
                if (opponents.User.HitPoints > 0)
                {
                    var act = RoundProcess(opponents.User, opponents.Monster);
                    act.CharacterName = opponents.User.Name;
                    ActionsList.Add(act);
                }
                else
                {
                    Winner = Winner.Monster;
                }

                if (opponents.Monster.HitPoints > 0)
                {
                    var act = RoundProcess(opponents.Monster, opponents.User);
                    act.CharacterName = opponents.Monster.Name;
                    ActionsList.Add(act); 
                }
                else
                {
                    Winner = Winner.Monster;
                }
            }

            return ActionsList;
        }

        public CharactersActions RoundProcess(Stats fighter1, Stats fighter2)
        {
            var action = new CharactersActions();
            var rnd = new Random();
            for (var i = 0; i < fighter1.AttackPerRound; i++)
            {
                var d20Result = rnd.Next(1, 21);
      
                action.d20RollResult = d20Result + fighter1.AttackModifier;
                if ((d20Result == 20 || action.d20RollResult >= fighter2.ArmorClass) && d20Result != 1)
                {
                    action.TypeOfHit = HitType.Hit;
                    var damage = 0;

                    for (var j = 0; j < fighter1.NumberOfThrows; j++)
                    {
                        damage += rnd.Next(1, fighter1.EdgeCount + 1);

                        var damageCoef = d20Result == 20 ? 2 : 1;

                        if (damageCoef == 2)
                            action.TypeOfHit = HitType.Crit;

                        action.Damage += (damage + fighter1.Weapon + fighter1.DamageModifier) * damageCoef;
                    }
                    
                    fighter2.HitPoints -= action.Damage;
                }
                else
                {
                    action.TypeOfHit = HitType.Miss;
                }
            }
            
            return action;
        }
    }
}