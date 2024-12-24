using Application.Commands;
using Domain.PersonInfos;
using MediatR;
using OvetimePolicies;

namespace Application.CommanHandlers
{
    public class UpdatePersonInfoCommandHandler : IRequestHandler<UpdatePersonInfoCommand, long>
    {
        private readonly IPersonInfoWriteRepository _repository;

        public UpdatePersonInfoCommandHandler(IPersonInfoWriteRepository repository)
        {
            _repository = repository;
        }
        public async Task<long> Handle(UpdatePersonInfoCommand command, CancellationToken cancellationToken)
        {
            var personInfo = await _repository.GetAsync(x=>x.Id == command.Id);
            if (personInfo == null)
            {
                throw new Exception("اطلاعات مورد نظر یافت نشد");
            }

            IOvertimeCalculator overtimeCalculator = GetOvertimeCalculator(command.OvertimePolicy);

            var salaryCalculator = new SalaryCalculator(overtimeCalculator);
            var salaryAfterTax = salaryCalculator.CalculateSalary(
                command.BasicSalary,
                command.Allowance,
                command.Transportation,
                command.Tax
            );

            personInfo.Update
                (
                command.Name,
                command.Family,
                command.Date,
                command.BasicSalary,
                command.Allowance,
                command.Transportation,
               salaryAfterTax
                );

            await _repository.SaveEntityChanges();

            return personInfo.Id;
        }
        private IOvertimeCalculator GetOvertimeCalculator(string overtimePolicy)
        {
            return overtimePolicy switch
            {
                "A" => new OvertimeCalculatorA(),
                "B" => new OvertimeCalculatorB(),
                "C" => new OvertimeCalculatorC(),
                _ => throw new ArgumentException("Invalid Overtime Policy")
            };
        }
    }
}
