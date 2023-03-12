using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class RealEstateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RealEstateController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var realEstates = _context.RealEstates.ToList();
            return View(realEstates);
        }

        // GET: RealEstate/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: RealEstate/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add([Bind("Id, PropertyType, Address, Description, Price")] RealEstate realEstate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realEstate);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(realEstate);
        }
    }
}
