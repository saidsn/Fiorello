using System.ComponentModel.DataAnnotations;

namespace FiorelloApp.ViewModels.AccountViewModels
{
    public class ForgotPasswordVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
