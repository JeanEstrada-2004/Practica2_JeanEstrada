using System.ComponentModel.DataAnnotations;

namespace Practica2_JeanEstrada.Models
{
    public class Adopter
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string FullName { get; set; } = string.Empty;

        public ICollection<Adoption> Adoptions { get; set; } = new List<Adoption>();
    }
}
