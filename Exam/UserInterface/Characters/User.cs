using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UserInterface.Characters;

namespace UserInterface
{
    public class User : Stats
    {
        [Required]
        [DisplayName("User Name")]
        [Column(TypeName = "varchar(500)")]
        public string Name { get; set; }
    }
}