using BookFlow___Library_Management_System.Data.Dtos;
using MediatR;

namespace BookFlow___Library_Management_System.CQRS.Queries
{
    public class GetBookByIdQuery : IRequest<BookDto>

    {
        public int Id { get; set; }

    }
}
