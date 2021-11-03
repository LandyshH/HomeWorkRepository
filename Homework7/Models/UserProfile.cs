using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public enum Sex
    {
        Male,
        Female
    }
    public class UserProfile
    {
        [Required (ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        
        [Required (ErrorMessage = "Не указана фамилия")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        
        [Required (ErrorMessage = "Не указан возраст")]
        [Range(1, 110, ErrorMessage = "Недопустимый возраст")]
        [DisplayName("Возраст")]
        public int Age { get; set; }
        
        [DisplayName("Пол")]
        public Sex Sex { get; set; }
    }
}
