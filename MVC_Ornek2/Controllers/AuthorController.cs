using Microsoft.AspNetCore.Mvc;
using MVC_Ornek2.Context;
using MVC_Ornek2.Models;

namespace MVC_Ornek2.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryDbContext _db;

        public AuthorController(LibraryDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var authors = _db.Authors.Where( x => x.IsDeleted == false ).ToList();
            return View(authors);
        }


        //[HttpGet] def
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author formData)
        {
            _db.Authors.Add(formData);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var author = _db.Authors.Find(id);

            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author formData)
        {
            formData.ModifiedDate = DateTime.Now;

            _db.Authors.Update(formData);

            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var author = _db.Authors.Find(id);

            author.IsDeleted = true;
            author.ModifiedDate = DateTime.Now;

            _db.Authors.Update(author);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
