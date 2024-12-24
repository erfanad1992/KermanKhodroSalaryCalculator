namespace OvetimePolicies
{
    public class SalaryCalculator
    {
        private readonly IOvertimeCalculator _overtimeCalculator;

        public SalaryCalculator(IOvertimeCalculator overtimeCalculator)
        {
            _overtimeCalculator = overtimeCalculator;
        }

        public decimal CalculateSalary(decimal baseSalary, decimal allowance, decimal transportation, decimal tax)
        {
            decimal overtime = _overtimeCalculator.Calculate(baseSalary, allowance);
            decimal totalSalary = baseSalary + allowance + transportation + overtime;
            return totalSalary - tax;
        }
    }
}
