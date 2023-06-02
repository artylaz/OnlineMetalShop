using System.ComponentModel.DataAnnotations;

namespace OnlineStore.WebMVC.Models.ClientViewModel.DTO
{
    public class UserAccountDto
    {
        [Required(ErrorMessage = "Не указана фамилия")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Не указано имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Не указан Email")]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; } = null!;
        [Required(ErrorMessage = "Не указан телефон")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; } = null!;
    }
}
