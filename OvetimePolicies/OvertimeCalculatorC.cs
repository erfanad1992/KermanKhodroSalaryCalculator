namespace OvetimePolicies
{

    public class OvertimeCalculatorC : IOvertimeCalculator
    {
        public decimal Calculate(decimal baseSalary, decimal attraction)
        {
            return (baseSalary + attraction) * 2.0m;
        }
    }
}
