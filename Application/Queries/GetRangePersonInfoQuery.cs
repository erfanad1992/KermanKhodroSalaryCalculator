using MediatR;

namespace Application.Queries
{
    public class GetRangePersonInfoQuery : IRequest<GetRangePersonInfoQueryResult>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

    }
}
