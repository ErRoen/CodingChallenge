using CodingChallenge.Application.Employees.Queries;
using CodingChallenge.Application.Interfaces;

namespace CodingChallenge.Application.Employees.Commands
{
    public class CreateEmployeeCommand : ICreateEmployeeCommand
    {
        private  readonly IDatabaseService _databaseService;

        public CreateEmployeeCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public void Execute(EmployeeModel employeeModel)
        {
            var employee = EmployeeConverter
                .CreateEmployee(employeeModel);

            _databaseService.Employees.Add(employee);
            _databaseService.Save();
        }
    }
}