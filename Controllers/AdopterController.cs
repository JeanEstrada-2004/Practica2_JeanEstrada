using Microsoft.AspNetCore.Mvc;
using Practica2_JeanEstrada.Data;
using Practica2_JeanEstrada.Models;

namespace Practica2_JeanEstrada.Controllers
{
    public class AdopterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdopterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Adopter adopter)
        {
            if (!ModelState.IsValid)
                return View(adopter);

            _context.Adopters.Add(adopter);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}
