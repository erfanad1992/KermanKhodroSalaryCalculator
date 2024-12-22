namespace Domain.PersonInfos
{
    public class PersonInfo
    {
        private PersonInfo()
        {

        }
        public PersonInfo(
            long id,
            string name,
            string family,
            DateTimeOffset date,
            decimal basicSalary,
            decimal allowance,
            decimal transportation,
            decimal salaryAfterTax)
        {
            Id = id;
            Name = name;
            Family = family;
            Date = date;
            BasicSalary = basicSalary;
            Allowance = allowance;
            Transportation = transportation;
            SalaryAfterTax = salaryAfterTax;
        }



        public long Id { get;private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public DateTimeOffset Date { get; private set; }
        public decimal BasicSalary { get; private set; }
        public decimal Allowance { get; private set; }
        public decimal Transportation { get; private set; }
        public decimal SalaryAfterTax { get; private set; }

        public void Update(
          string name,
          string family,
          DateTimeOffset date,
          decimal basicSalary,
          decimal allowance,
          decimal transportation,
          decimal salaryAfterTax
          )
        {
            Name = name;
            Family = family;
            Date = date;
            BasicSalary = basicSalary;
            Allowance = allowance;
            Transportation = transportation;
            SalaryAfterTax = salaryAfterTax;
        }


    }
}
