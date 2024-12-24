using Application.Queries;
using Domain.PersonInfos;
using MediatR;

namespace Application.QueryHandlers
{
    public class GetRangePersonInfoQueryHandler : IRequestHandler<GetRangePersonInfoQuery, GetRangePersonInfoQueryResult>
    {
        private readonly IPersonInfoReadRepository _repository;
        public GetRangePersonInfoQueryHandler(IPersonInfoReadRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetRangePersonInfoQueryResult> Handle(GetRangePersonInfoQuery request, CancellationToken cancellationToken)
        {
            var rangePersonInfo = await _repository.GetListAsync(request.Name, request.Family, request.StartDate, request.EndDate);

            var queryResult = new GetRangePersonInfoQueryResult
            {
                QueryResult = rangePersonInfo,

            };
            return queryResult;
        }
    }
}
