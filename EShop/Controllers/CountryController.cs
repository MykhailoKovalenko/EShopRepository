using EShop.Data;
using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    public class CountryController : Controller
    {
        private readonly ApplicationDBContext _context;
        public CountryController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Country> countries = _context.Countries;
            return View(countries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
