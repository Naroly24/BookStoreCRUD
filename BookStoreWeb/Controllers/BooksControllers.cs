using Microsoft.AspNetCore.Mvc;
using BookStoreWeb.Models; 
using System.Threading.Tasks;
using BookStoreCRUD.Domain.Models;


public class BooksController : Controller
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<IActionResult> Index()
    {
        var books = await _bookService.GetBooksAsync();
        return View(books);
    }

    public async Task<IActionResult> Details(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        return View(book);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        if (ModelState.IsValid)
        {
            await _bookService.CreateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Book book)
    {
        if (ModelState.IsValid)
        {
            await _bookService.UpdateBookAsync(book);
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
