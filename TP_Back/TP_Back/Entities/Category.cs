namespace TP_Back.Entities
{
    public class Category : GenericEntity
    {

        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }

        public List<Thing>? Things { get; set; }

    }
}
