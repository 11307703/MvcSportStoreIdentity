using System.ComponentModel.DataAnnotations;

namespace MvcSportStore.ViewModels.IdentityViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
