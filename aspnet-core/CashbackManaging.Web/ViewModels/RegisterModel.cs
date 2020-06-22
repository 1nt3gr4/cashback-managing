using System.ComponentModel.DataAnnotations;

namespace CashbackManaging.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано подтверждение пароля")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}