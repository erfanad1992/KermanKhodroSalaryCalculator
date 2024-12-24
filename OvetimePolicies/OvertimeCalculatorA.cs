namespace OvetimePolicies
{
    public class OvertimeCalculatorA : IOvertimeCalculator
    {
        public decimal Calculate(decimal baseSalary, decimal attraction)
        {
            return (baseSalary + attraction) * 1.25m;
        }
    }
}
