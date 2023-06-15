using Microsoft.AspNetCore.Mvc;
using MVC_Ornek2.Context;
using MVC_Ornek2.Models;

namespace MVC_Ornek2.Controllers
{
    public class BookTypeController : Controller
    {
        private readonly LibraryDbContext _db;

        //readonly müdahalenin yalnızca ctorda yapılabileceğini gösterir

        public BookTypeController(LibraryDbContext db)
        {
            _db = db;
        }

        //Dependency Injection
        //_db -> BookTypeController'a her istek atıldığında kullanılacak veritabanı koyyası.

        // Bir class'a ait olan prop ve metotların başka bir class içinde kullanılması için o class'ın newlenmesi gerekir.

        //Dependency Injection ile newleme işlemini otomatiğe bağlıyorum.

        public IActionResult Index()
        {
            var bookTypes = _db.BookTypes.Where(x => x.IsDeleted == false).ToList();  //.ToList ile DbSet olan veriyi List e çevirdik.
            return View("List" , bookTypes);
        }

        [HttpGet] //default olarak actionlar httpget olur
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //formdan tetiklenen action
        public IActionResult Create(BookType formData)
        {
            _db.BookTypes.Add(formData); //veritabanı örneğine veriyi ekledim.

            _db.SaveChanges(); //asıl veritabanına kayıt ettim

            return RedirectToAction("Index");
            //Index action'a yönlendir ve kodları çalıştır
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bookType = _db.BookTypes.Find(id);

            return View(bookType);
        }

        [HttpPost]
        public IActionResult Edit(BookType formData)
        {
            formData.ModifiedDate = DateTime.Now;

            _db.BookTypes.Update(formData);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            //HARD DELETE

            //var bookType = _db.BookTypes.Find(id);
            //_db.BookTypes.Remove(bookType);
            //_db.SaveChanges();

            //SOFT DELETE(UPDATE)

            var bookType = _db.BookTypes.Find(id);

            bookType.IsDeleted = true;
            bookType.ModifiedDate = DateTime.Now;

            _db.BookTypes.Update(bookType);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
