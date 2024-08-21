using System.ComponentModel.DataAnnotations;

namespace Lesson_10_identity.ViewModels;

public class RegisterVm
{
    [Required(ErrorMessage ="Ad Bosh ola bilmez")]
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
    public bool IsAgree { get; set; }=true;
}
