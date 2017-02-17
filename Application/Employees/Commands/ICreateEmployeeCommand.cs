using System.Linq;
using CodingChallenge.Application.Employees.Queries;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Employees.Commands
{
    public interface ICreateEmployeeCommand
    {
        void Execute(EmployeeModel employeeModel);
    }
}