using System;

namespace TP_Back.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Thing Thing { get; set; }
        public Person Person { get; set; }
    }
}
