using System.Net;

namespace TP_Back.Entities
{
    public class Person: GenericEntity
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

    }
}
