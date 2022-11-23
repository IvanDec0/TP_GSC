using System.Net;

namespace TP_Back.Entities
{
    public class Person: GenericEntity
    {
        public String? Name { get; set; }
        public String? PhoneNumber { get; set; }
        public String? Email { get; set; }

    }
}
