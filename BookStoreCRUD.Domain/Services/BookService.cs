using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStoreCRUD.Domain.Data;
using BookStoreCRUD.Domain.Models;

namespace BookStoreCRUD.Domain.Services
{
    public class BookService
    {
        private readonly AppDBContext _context;

        public BookService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task CreateBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
