using BookFlow___Library_Management_System.Data;
using BookFlow___Library_Management_System.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class BorrowingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BorrowingsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("my-borrowed-books")]
    public async Task<IActionResult> GetMyBorrowedBooks()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return Unauthorized();

        var data = await _context.Set<BorrowRecord>()
            .Include(b => b.Book)
            .Where(b => b.UserId == userId)
            .Select(b => new
            {
                bookTitle = b.Book.Title,
                borrowDate = b.BorrowDate,
                returnDate = b.ReturnDate,
                isReturned = b.ReturnDate != null
            })
            .ToListAsync();

        return Ok(data);
    }
}