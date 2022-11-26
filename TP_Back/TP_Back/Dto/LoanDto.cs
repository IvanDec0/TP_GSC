using TP_Back.Entities;

namespace TP_Back.Dto
{
    public class LoanDto
    {
        public ThingDto Thing { get; set; }
        public Person Person { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }
    }
}
