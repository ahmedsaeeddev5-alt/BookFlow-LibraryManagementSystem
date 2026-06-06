using BookFlow___Library_Management_System.Data.Dtos;
using MediatR;

namespace BookFlow___Library_Management_System.CQRS.Commands
{
    public class UpdateBookCommand : IRequest<string>

    {
        public UpdateBookDto Book { get; set; }
        public int Id { get; internal set; }
    }
}
