using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.Characters
{
    public class Monster : Stats
    {
        [Required]
        [DisplayName("Monster Name")]
        [Column(TypeName = "varchar(500)")]
        public string Name { get; set; }
    }
}