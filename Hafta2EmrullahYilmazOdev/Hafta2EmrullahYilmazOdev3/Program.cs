using static Hafta2EmrullahYilmazOdev3.Solid;

var employeeDetailsModified = new EmployeeDetailsModified(new SalaryCalculatorModified(), new DateCalculatorModified());
employeeDetailsModified.HourlyRate = 50;
employeeDetailsModified.HoursWorked = 150;
Console.WriteLine($"The Total Pay is {employeeDetailsModified.GetSalary()}");
Console.ReadKey();