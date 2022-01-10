using System;

namespace BusinessLogic.FightLogic
{
    public enum HitType : byte
    {
        Miss = 1,
        Hit = 2,
        Crit = 3
    }

    public static class HitTypeExtensions
    {
        public static string HitTypeToString(this HitType hitType)
        {
            return hitType switch
            {
                HitType.Miss => "промах",
                HitType.Crit => "критический удар",
                HitType.Hit => "попадание",
                _ => throw new ArgumentOutOfRangeException(nameof(hitType), hitType, null)
            };
        }
    }
}