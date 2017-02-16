using System.Linq;
using CodingChallenge.Application.Interfaces;

namespace CodingChallenge.Application.Employees.Queries
{
    public class GetEmployeeQuery : IGetEmployeeQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetEmployeeQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public EmployeeModel Execute(int id)
        {
            return _databaseService.Employees
                .Select(e => EmployeeConverter.CreateEmployeeModel(e, _databaseService))
                .SingleOrDefault(e => e.Id == id);
        }
    }
}