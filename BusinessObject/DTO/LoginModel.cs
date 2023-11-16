using System.ComponentModel.DataAnnotations;

namespace WebBookStoreAPI.DTO
{
    public class LoginModel
    { 
     
        [Required]
    public string User_Email { get; set; }

    [Required]
    public string User_Password { get; set; }

}
}
