using BookFlow___Library_Management_System.Data.Dtos;
using MediatR;

namespace BookFlow___Library_Management_System.CQRS.Queries
{
    public class SearchBooksQuery : IRequest<List<BookDto>>
    {
        public string Title { get; set; }

    }
}
