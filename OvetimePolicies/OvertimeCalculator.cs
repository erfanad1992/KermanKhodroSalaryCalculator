namespace OvetimePolicies;

public static class OvertimeCalculator
{
    public static decimal CalcurlatorC(decimal baseSalary, decimal allowance)
    {

        return 0;
    }

    public static decimal CalcurlatorB(decimal baseSalary, decimal allowance)
    {

        return baseSalary + allowance;
    }

    public static decimal CalcurlatorA(decimal baseSalary, decimal allowance)
    {

        return 0;
    }

    public static decimal CalculateSalary(decimal baseSalary, decimal allowance, decimal transportation, decimal tax)
    {

        decimal overtime = CalcurlatorB(baseSalary, allowance);

        decimal taxedSalary = baseSalary + allowance + transportation + overtime;

        decimal salaryAfterTax = taxedSalary - tax;

        return salaryAfterTax;
    }

}

