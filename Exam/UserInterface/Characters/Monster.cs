using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserInterface.Characters;

namespace UserInterface
{
    public class Monster : Stats
    {
        [Required]
        [DisplayName("Monster Name")]
        [Column(TypeName = "varchar(500)")]
        public string Name { get; set; }
    }
}