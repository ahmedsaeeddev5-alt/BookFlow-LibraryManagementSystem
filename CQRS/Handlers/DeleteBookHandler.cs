using BookFlow___Library_Management_System.CQRS.Commands;
using BookFlow___Library_Management_System.Repository;
using MediatR;

namespace BookFlow___Library_Management_System.CQRS.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, string>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<string> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
                return "Book Not Found";

            _bookRepository.Delete(book);
            await _bookRepository.SaveChangesAsync();

            return "Book Deleted Successfully";
        }
    }
}
