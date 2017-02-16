using System.Linq;
using CodingChallenge.Application.Employees.Queries;
using CodingChallenge.Application.Interfaces;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Employees.Commands
{
    public interface ICreateEmployeeCommand
    {
        void Execute(EmployeeModel employeeModel);
    }

    public class CreateEmployeeCommand : ICreateEmployeeCommand
    {
        private  readonly IDatabaseService _databaseService;

        public CreateEmployeeCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public void Execute(EmployeeModel employeeModel)
        {
            var employee = EmployeeConverter.CreateEmployee(
                employeeModel, 
                _databaseService);

            _databaseService.Employees.Add(employee);
        }
    }
}