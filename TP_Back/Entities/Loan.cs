using System;

namespace TP_Back.Entities
{
    public class Loan: GenericEntity
    {
        public Thing Thing { get; set; }
        public Person Person { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string? Status { get; set; }
    }
}
