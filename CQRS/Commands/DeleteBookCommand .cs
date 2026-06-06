using MediatR;

namespace BookFlow___Library_Management_System.CQRS.Commands
{
    public class DeleteBookCommand : IRequest<string>
    {
        public int Id { get; set; }

    }
}
