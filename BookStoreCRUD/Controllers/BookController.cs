using Microsoft.AspNetCore.Mvc;
using BookStoreCRUD.Data;
using BookStoreCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace BookStoreCRUD.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDBContext _appdbContext;

        public BookController(AppDBContext appDBContext)
        {
            _appdbContext = appDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Book> lista = await _appdbContext.Books.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nuevo(Book book)
        {
            if (ModelState.IsValid)
            {
                await _appdbContext.Books.AddAsync(book);
                await _appdbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Lista)); 
            }
            return View(book); 
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var book = await _appdbContext.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound(); 
            }
            return View(book); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Book book)
        {
            if (ModelState.IsValid)
            {
                _appdbContext.Books.Update(book); 
                await _appdbContext.SaveChangesAsync(); 
                return RedirectToAction(nameof(Lista)); 
            }
            return View(book); 
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            var book = await _appdbContext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound(); 
            }

            _appdbContext.Books.Remove(book);
            await _appdbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }


    }
}
