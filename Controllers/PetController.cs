using Microsoft.AspNetCore.Mvc;
using Practica2_JeanEstrada.Data;
using Practica2_JeanEstrada.Models;

namespace Practica2_JeanEstrada.Controllers
{
    public class PetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pet pet)
        {
            if (!ModelState.IsValid || pet.Age < 0)
            {
                ModelState.AddModelError("Age", "La edad debe ser positiva.");
                return View(pet);
            }

            _context.Pets.Add(pet);
            _context.SaveChanges();

            return RedirectToAction("Create"); // O redirige a una vista de confirmación
        }
    }
}
