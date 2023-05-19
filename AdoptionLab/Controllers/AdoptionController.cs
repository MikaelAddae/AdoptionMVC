using AdoptionLab.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoptionLab.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly AdoptionDbContext _context;
        public AdoptionController(AdoptionDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
