﻿using MediatR;

namespace Application.Commands
{
    public class AddPersonInfoCommand : IRequest<long>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowance { get; set; }
        public decimal Transportation { get; set; }
        public decimal Tax { get; set; }
        public string OvertimePolicy { get; set; }
    }
}
