namespace Hafta2EmrullahYilmazOdev3
{
    public interface IEmployeeDetailsModified
    {
        int HourlyRate { get; set; }
        int HoursWorked { get; set; }

        float GetSalary();
    }
}