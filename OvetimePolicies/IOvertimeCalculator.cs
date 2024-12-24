namespace OvetimePolicies
{
    public interface IOvertimeCalculator
    {
        decimal Calculate(decimal baseSalary, decimal attraction);
    }
}
