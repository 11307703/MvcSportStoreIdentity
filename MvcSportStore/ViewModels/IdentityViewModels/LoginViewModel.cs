using System.ComponentModel.DataAnnotations;

namespace MvcSportStore.ViewModels.IdentityViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
