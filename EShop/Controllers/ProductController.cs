using EShop.Data;
using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Products;

            foreach(var product in products)
            {
                product.Category = _context.Categories.FirstOrDefault(i => i.Id == product.CategoryId);
            }

            return View(products);
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryDropDown = _context.Categories.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.CategoryDropDown = CategoryDropDown;

            Product product = new Product();

            if (id == null)
            {
                return View(product);    
            }
            else
            {
                product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //    public IActionResult Edit(int? id)
        //    {
        //        if (id == null || id == 0)
        //        {
        //            return NotFound();
        //        }

        //        var category = _context.Categories.Find(id);
        //        if (category == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(category);
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult Edit(Category category)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(category);
        //        }
        //        _context.Categories.Update(category);
        //        _context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }

        //    public IActionResult Delete(int? id)
        //    {
        //        if (id == null || id == 0)
        //        {
        //            return NotFound();
        //        }

        //        var category = _context.Categories.Find(id);
        //        if (category == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(category);
        //    }

        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public IActionResult DeletePost(int? id)
        //    {
        //        var category = _context.Categories.Find(id);
        //        if (category == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Categories.Remove(category);
        //        _context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //}
    }
}
