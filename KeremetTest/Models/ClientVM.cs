using System.ComponentModel.DataAnnotations;

namespace KeremetTest.Models
{
    public class ClientVM
    {
        [Display(Name = "ИНН клиента")]
        [Required(ErrorMessage = "Не указан ИНН клиента")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Пожалуйста, введите число")]
        [MaxLength(14)]
        public string SocialNumber { get; set; }
    }
}
