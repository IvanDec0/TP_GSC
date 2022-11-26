namespace TP_Back.Entities
{
    public class Thing: GenericEntity
    {
        public string? Description { get; set; }
        public Category Category { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
