using BookFlow___Library_Management_System.CQRS.Commands;
using BookFlow___Library_Management_System.Repository;
using MediatR;

namespace BookFlow___Library_Management_System.CQRS.Handlers
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Data.Models.Book
            {
                Title = request.Book.Title,
                Author = request.Book.Author,
                Quantity = request.Book.Quantity,
                CategoryId = request.Book.CategoryId
            };

            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveChangesAsync();

            return book.Id;
        }
    }
}
