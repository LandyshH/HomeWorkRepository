using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserInterface.Characters
{
    public class Stats
    {
        [Required]
        [Range(0, 500)]
        [DisplayName("Hit Points")]
        public int HitPoints { get; set; }
                
        [Required]
        [Range(0, 300)]
        [DisplayName("Attack Modifier +")]
        public int AttackModifier { get; set; }
                
        [Required]
        [Range(0, 100)]
        [DisplayName("Attack Per Round")]
        public int AttackPerRound { get; set; }
                
        [Required]
        [DisplayName("Number of throws")]
        [Range(0, 10)]
        public int NumberOfThrows { get; set; }
        
        [Required]
        [DisplayName("Edge count")]
        [Range(0, 20)]
        public int EdgeCount { get; set; }
                
        [Required]
        [Range(0, 300)]
        [DisplayName("Damage Modifier +")]
        public int DamageModifier { get; set; }
                
        [Required]
        [Range(0, 300)]
        [DisplayName("Weapon +")]
        public int Weapon { get; set; }
        
        [Required]
        [Range(0, 100)]
        [DisplayName("Armor Class")]
        public int ArmorClass { get; set; }
    }
}