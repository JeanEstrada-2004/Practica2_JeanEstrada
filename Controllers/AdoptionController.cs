using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica2_JeanEstrada.Data;
using Practica2_JeanEstrada.Models;

namespace Practica2_JeanEstrada.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Pets = _context.Pets
                .Where(p => p.AdoptionStatus == "Disponible")
                .ToList();

            ViewBag.Adopters = _context.Adopters.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(int petId, int adopterId)
        {
            var pet = _context.Pets.Find(petId);

            if (pet == null || pet.AdoptionStatus == "Adoptada")
            {
                ModelState.AddModelError("", "La mascota no está disponible.");
                return RedirectToAction("Create");
            }

            var adoption = new Adoption
            {
                PetId = petId,
                AdopterId = adopterId
            };

            pet.AdoptionStatus = "Adoptada";
            _context.Adoptions.Add(adoption);
            _context.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult List()
        {
            var adoptions = _context.Adoptions
                .Include(a => a.Pet)
                .Include(a => a.Adopter)
                .ToList();

            return View(adoptions);
        }
    }
}
