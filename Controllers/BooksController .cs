using BookFlow___Library_Management_System.CQRS.Commands;
using BookFlow___Library_Management_System.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookFlow___Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery { Id = id });

            if (result == null)
                return NotFound("Book not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { message = "Book Created", id = result });
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { message = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBookCommand { Id = id });
            return Ok(new { message = result });
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string title)
        {
            var result = await _mediator.Send(new SearchBooksQuery { Title = title });
            return Ok(result);
        }
    }
}
