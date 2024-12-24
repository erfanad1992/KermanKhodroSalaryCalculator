using Application.Commands;
using System.Text.Json.Serialization;

namespace WebApi.Controllers.Models
{

    public class UpdatePersonInfoModel
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Transportation { get; set; }
        public decimal Tax { get; set; }

        internal UpdatePersonInfoCommand ToCommand()
        {
            return new UpdatePersonInfoCommand
            {
                Id = Id,
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
