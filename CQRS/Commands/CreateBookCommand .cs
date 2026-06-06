using BookFlow___Library_Management_System.Data.Dtos;
using MediatR;

namespace BookFlow___Library_Management_System.CQRS.Commands
{
    public class CreateBookCommand : IRequest<int>
    {
        public CreateBookDto Book { get; set; }
    }
}
