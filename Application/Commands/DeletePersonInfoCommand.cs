using MediatR;

namespace Application.Commands
{
    public class DeletePersonInfoCommand : IRequest<long>
    {
        public long Id { get; set; }
    }
}
