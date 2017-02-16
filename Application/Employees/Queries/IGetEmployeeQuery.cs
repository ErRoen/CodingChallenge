namespace CodingChallenge.Application.Employees.Queries
{
    public interface IGetEmployeeQuery
    {
        EmployeeModel Execute(int id);
    }
}