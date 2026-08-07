using BookFlow___Library_Management_System.Data;
using BookFlow___Library_Management_System.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class BorrowingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BorrowingsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Borrowings/my-borrowed-books
    [HttpGet("my-borrowed-books")]
    public async Task<IActionResult> GetMyBorrowedBooks()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return Unauthorized();

        var data = await _context.BorrowRecords
            .Include(b => b.Book)
            .Where(b => b.UserId == userId)
            .Select(b => new
            {
                bookId = b.BookId,
                bookTitle = b.Book.Title,
                borrowDate = b.BorrowDate,
                returnDate = b.ReturnDate,
                isReturned = b.ReturnDate != null
            })
            .ToListAsync();

        return Ok(data);
    }

    // POST: api/Borrowings/borrow/{bookId}
    [HttpPost("borrow/{bookId}")]
    public async Task<IActionResult> BorrowBook(int bookId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return Unauthorized();

        var book = await _context.Books.FindAsync(bookId);

        if (book == null)
            return NotFound("Book not found.");

        var alreadyBorrowed = await _context.BorrowRecords
            .AnyAsync(b => b.BookId == bookId &&
                           b.ReturnDate == null);

        if (alreadyBorrowed)
            return BadRequest("Book is already borrowed.");

        var borrow = new BorrowRecord
        {
            BookId = bookId,
            UserId = userId,
            BorrowDate = DateTime.UtcNow,
            ReturnDate = null
        };

        _context.BorrowRecords.Add(borrow);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Book borrowed successfully."
        });
    }

    // POST: api/Borrowings/return/{bookId}
    [HttpPost("return/{bookId}")]
    public async Task<IActionResult> ReturnBook(int bookId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return Unauthorized();

        var borrow = await _context.BorrowRecords
            .FirstOrDefaultAsync(x =>
                x.BookId == bookId &&
                x.UserId == userId &&
                x.ReturnDate == null);

        if (borrow == null)
            return NotFound("Borrow record not found.");

        borrow.ReturnDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Book returned successfully."
        });
    }
}