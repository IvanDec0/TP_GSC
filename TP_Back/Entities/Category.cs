namespace TP_Back.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Thing> Things { get; set; }
    }
}
