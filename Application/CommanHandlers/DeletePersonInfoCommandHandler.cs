using Application.Commands;
using Domain.PersonInfos;
using MediatR;

namespace Application.CommanHandlers
{
    public class DeletePersonInfoCommandHandler : IRequestHandler<DeletePersonInfoCommand, long>
    {
        private readonly IPersonInfoWriteRepository _repository;

        public DeletePersonInfoCommandHandler(IPersonInfoWriteRepository repository)
        {
            _repository = repository;
        }
        public async Task<long> Handle(DeletePersonInfoCommand command, CancellationToken cancellationToken)
        {
            var personInfo = await _repository.GetAsync(x=>x.Id == command.Id);
            if (personInfo is null)
            {
                throw new Exception("موجودیت مورد نظر یافت نشد");

            }
           await _repository.RemoveAsync(personInfo);

            return personInfo.Id;
        }
    }
}
