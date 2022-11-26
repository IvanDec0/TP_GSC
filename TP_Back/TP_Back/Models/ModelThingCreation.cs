using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TP_Back.Dto;

namespace TP_Back.Models
{
    public class ModelThingCreation
    {

        public List<CategoryDto> Categories = new List<CategoryDto>();


        [Required(ErrorMessage = "Description is requiered")]
        [MinLength(3, ErrorMessage = "Should have more then 3 letters")]
        [MaxLength(99, ErrorMessage = "Can't have more then 100 letterns")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Category is requiered")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

    }
}

