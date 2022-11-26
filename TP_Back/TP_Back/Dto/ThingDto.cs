namespace TP_Back.Dto
{
    public class ThingDto
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public CategoryDto Category { get; set; }

        public ThingDto()
        {
            Category = new CategoryDto();
        }

    }
}
