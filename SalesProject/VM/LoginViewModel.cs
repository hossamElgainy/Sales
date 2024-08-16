using System.ComponentModel.DataAnnotations;

namespace SalesProject.VM
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="برجاء إدخال البريد الإلكتروني")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "برجاء إدخال كلمه السر")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
