namespace OvetimePolicies
{
    public class OvertimeCalculatorB : IOvertimeCalculator
    {
        public decimal Calculate(decimal baseSalary, decimal attraction)
        {
            return (baseSalary + attraction) * 1.5m;
        }
    }
}
