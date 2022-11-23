using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Back.Entities
{
    public class User : GenericEntity
    {
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


    }
}
