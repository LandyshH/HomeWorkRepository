using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase.Models
{
    public class Monster
    {
        public int Id { get; set; }

        [Required]
        
        [DisplayName("Monster Name")]
        [Column(TypeName = "varchar(500)")]
        public string Name { get; set; }
        
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
        [Range(0, 500)]
        [DisplayName("Damage")]
        public int Damage { get; set; }
                
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