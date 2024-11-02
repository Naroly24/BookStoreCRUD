using Microsoft.AspNetCore.Mvc;
using BookStoreCRUD.Domain.Data;
using BookStoreCRUD.Domain.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly AppDBContext _context;

    public BooksController(AppDBContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
    }
}
