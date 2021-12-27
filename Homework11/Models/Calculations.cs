using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework11.Database.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Expression { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Result { get; set; }
    }
}