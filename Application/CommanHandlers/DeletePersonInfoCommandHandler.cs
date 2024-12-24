using Application.Commands;
using MediatR;

namespace Application.CommanHandlers
{
    //public class DeletePersonInfoCommandHandler : IRequestHandler<DeletePersonInfoCommand, long>
    //{
    //    private readonly IPersonInfoRepository _repository;

    //    public DeletePersonInfoCommandHandler(IPersonInfoRepository repository)
    //    {
    //        _repository = repository;
    //    }
    //    public async Task<long> Handle(DeletePersonInfoCommand command, CancellationToken cancellationToken)
    //    {
    //        var personInfo = await _repository.GetAsync(command.Id);
    //        if (personInfo is null)
    //        {
    //            throw new Exception("موجودیت مورد نظر یافت نشد");

    //        }
    //        _repository.Remove(personInfo);

    //        return personInfo.Id;
    //    }
    //}
}
