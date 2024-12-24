using MediatR;

namespace Application.Queries
{
    public class GetPersonInfoQuery : IRequest<GetPersonInfoQueryResult>
    {
        public long Id { get; set; }
    }
}
