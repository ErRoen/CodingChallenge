using System.Data.Entity;
using System.Linq;
using CodingChallenge.Application.Benefits.Queries;
using CodingChallenge.Application.Interfaces;

namespace CodingChallenge.Application.Employees.Queries
{
    public class GetEmployeeQuery : IGetEmployeeQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IGetBenefitsDataQuery _getBenefitsDataQuery;

        public GetEmployeeQuery(IDatabaseService databaseService, IGetBenefitsDataQuery getBenefitsDataQuery)
        {
            _databaseService = databaseService;
            _getBenefitsDataQuery = getBenefitsDataQuery;
        }

        public EmployeeModel Execute(int id)
        {
            var databaseServiceBenefitsData = _getBenefitsDataQuery.Execute();

            var employee = _databaseService
                .Employees
                .Include("Dependents")
                .SingleOrDefault(e => e.Id == id);

            return EmployeeConverter
                .CreateEmployeeModel(employee, databaseServiceBenefitsData);
        }
    }
}