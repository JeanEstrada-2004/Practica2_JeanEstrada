using System.ComponentModel.DataAnnotations;
namespace Practica2_JeanEstrada.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "La edad debe ser positiva")]
        public int Age { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estado es obligatorio")]
        public string AdoptionStatus { get; set; } = "Disponible";

        public Adoption? Adoption { get; set; }
    }
}
