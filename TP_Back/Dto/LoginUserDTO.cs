using System.ComponentModel.DataAnnotations;

namespace TP_Back.Dto
{
    public class LoginUserDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
