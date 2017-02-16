using CodingChallenge.Domain;

namespace CodingChallenge.Application.Employees.Queries
{
    public interface IGetEmployeeQuery
    {
        Employee Execute(int id);
    }
}