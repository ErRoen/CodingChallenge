using System.Linq;
using CodingChallenge.Application.Interfaces;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Employees.Queries
{
    public class GetEmployeeQuery : IGetEmployeeQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetEmployeeQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public Employee Execute(int id)
        {
            return _databaseService.Employees.SingleOrDefault(e => e.Id == id);
        }
    }
}