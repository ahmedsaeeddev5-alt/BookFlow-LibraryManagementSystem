using BookFlow___Library_Management_System.CQRS.Queries;
using BookFlow___Library_Management_System.Data.Dtos;
using BookFlow___Library_Management_System.Repository;
using MediatR;

namespace BookFlow___Library_Management_System.CQRS.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookDto>>
    {
        private readonly IBookRepository _bookRepository;

        public GetAllBooksHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllAsync();

            var result = books.Select(x => new BookDto
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Quantity = x.Quantity,
                CategoryId = x.CategoryId,
                CategoryName = x.Category?.Name
            }).ToList();

            return result;
        }
    }
}
