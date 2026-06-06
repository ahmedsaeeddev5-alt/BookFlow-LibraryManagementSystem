using BookFlow___Library_Management_System.CQRS.Commands;
using BookFlow___Library_Management_System.Repository;
using MediatR;

namespace BookFlow___Library_Management_System.CQRS.Handlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, string>

    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<string> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Book.Id);

            if (book == null)
                return "Book Not Found";

            book.Title = request.Book.Title;
            book.Author = request.Book.Author;
            book.Quantity = request.Book.Quantity;
            book.CategoryId = request.Book.CategoryId;

            _bookRepository.Update(book);
            await _bookRepository.SaveChangesAsync();

            return "Book Updated Successfully";
        }
    }
}
