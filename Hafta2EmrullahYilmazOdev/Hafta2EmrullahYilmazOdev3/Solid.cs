using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hafta2EmrullahYilmazOdev3
{
    public class Solid //Dependency Inversion Principle 
    {
        public interface ISalaryCalculator
        {
            float CalculateSalary(int hoursWorked, float hourlyRate);
        }
        public interface ICalculateDate : ISalaryCalculator //Interface Segregation Principle  
        {
            DateTime Date { get; set; }
        }
        public class SalaryCalculatorModified : ISalaryCalculator
        {
            public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
        }
        public class DateCalculatorModified : ICalculateDate
        {
            public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public float CalculateSalary(int hoursWorked, float hourlyRate)
            {
                throw new NotImplementedException();
            }

            public DateTime GetDate(DateTime date) => date;
        }

        public class EmployeeDetailsModified
        {
            private readonly ISalaryCalculator _salaryCalculator;
            private readonly ICalculateDate _date;

            public int HoursWorked { get; set; }
            public int HourlyRate { get; set; }
            public EmployeeDetailsModified(ISalaryCalculator salaryCalculator, ICalculateDate date)
            {
                _salaryCalculator = salaryCalculator;
                _date = date;
                
            }
            public float GetSalary()
            {
                return _salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
            }
        }
    }
}
