using AdoptionLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdoptionLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AdoptionDbContext _adoptionDBContext;

        public HomeController(ILogger<HomeController> logger, AdoptionDbContext context)
        {
            _adoptionDBContext = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Animal> animals = _adoptionDBContext.Animals.ToList();
            
            return View(animals);
        }

        public IActionResult Results(string breed)
        {
            List<Animal> animals = _adoptionDBContext.Animals.Where(a => a.Breed == breed).ToList();
            return View(animals);
        }

        public IActionResult Adopt(int id)
        {
            Animal a = _adoptionDBContext.Animals.FirstOrDefault(a => a.Id == id);
            _adoptionDBContext.Animals.Remove(a);
            _adoptionDBContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddAnimal(Animal a)
        {
            if (a != null) 
            {
                _adoptionDBContext.Animals.Add(a);
                _adoptionDBContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Animal()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}