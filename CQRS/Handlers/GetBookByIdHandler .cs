using BookFlow___Library_Management_System.CQRS.Queries;
using BookFlow___Library_Management_System.Data.Dtos;
using BookFlow___Library_Management_System.Repository;
using MediatR;

namespace BookFlow___Library_Management_System.CQRS.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookDto>

    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
                return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Quantity = book.Quantity,
                CategoryId = book.CategoryId,
                CategoryName = book.Category?.Name
            };
        }
    }
}
