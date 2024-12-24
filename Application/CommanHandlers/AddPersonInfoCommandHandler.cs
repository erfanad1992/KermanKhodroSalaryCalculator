using Application.Commands;
using Domain.Interfaces;
using Domain.PersonInfos;
using MediatR;
using OvetimePolicies;

namespace Application.CommanHandlers
{
    public class AddPersonInfoCommandHandler : IRequestHandler<AddPersonInfoCommand, long>
    {
        private readonly IPersonInfoWriteRepository _repository;
        private readonly IIdGenerator _idGenerator;

        public AddPersonInfoCommandHandler(IPersonInfoWriteRepository repository, IIdGenerator idGenerator)
        {
            _repository = repository;
            _idGenerator = idGenerator;
        }
        public async Task<long> Handle(AddPersonInfoCommand command, CancellationToken cancellationToken)
        {

            IOvertimeCalculator overtimeCalculator = command.OvertimePolicy switch
            {
                "A" => new OvertimeCalculatorA(),
                "B" => new OvertimeCalculatorB(),
                "C" => new OvertimeCalculatorC(),
                _ => throw new ArgumentException("Invalid Overtime Policy")
            };

            var salaryCalculator = new SalaryCalculator(overtimeCalculator);

            var salaryAfterTax = salaryCalculator.CalculateSalary(
                command.BasicSalary,
                command.Allowance,
                command.Transportation,
                command.Tax
            );
            var personInfo = new PersonInfo
                (
                _idGenerator.GetNewId(),
                command.Name,
                command.Family,
                command.Date,
                command.BasicSalary,
                command.Allowance,
                command.Transportation,
                salaryAfterTax
                );
            await _repository.InsertAsync(personInfo);
            return personInfo.Id;
        }
    }
}
