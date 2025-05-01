namespace Practica2_JeanEstrada.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Type { get; set; } = string.Empty;
        public string AdoptionStatus { get; set; } = "Disponible";

        public Adoption? Adoption { get; set; }  // Relación 1 a 1
    }
}
