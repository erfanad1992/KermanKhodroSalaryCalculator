using Application.Commands;

namespace WebApi.Controllers.Models
{

    public class AddPersonInfoModel
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Transportation { get; set; }
        public decimal Tax { get; set; }

        internal AddPersonInfoCommand ToCommand()
        {
            return new AddPersonInfoCommand
            {
                Name = Name,
                Family = Family,
                Date = Date,
                BasicSalary = BasicSalary,
                Allowance = Allowance,
                Transportation = Transportation,
                Tax = Tax
            };
        }

    }
}
