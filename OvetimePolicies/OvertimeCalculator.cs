namespace OvetimePolicies;

public static class OvertimeCalculator
{

        public static decimal CalcurlatorA(decimal baseSalary, decimal attraction)
        {
            return (baseSalary + attraction) * 1.25m;
        }

        public static decimal CalcurlatorB(decimal baseSalary, decimal attraction)
        {
            return (baseSalary + attraction) * 1.5m;
        }

        public static decimal CalcurlatorC(decimal baseSalary, decimal attraction)
        {
            return (baseSalary + attraction) * 2.0m;
        }
    

}

