using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CodingChallenge.Application.Benefits.Queries;
using CodingChallenge.Application.Interfaces;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Employees.Queries
{
    public class GetEmployeeListQuery : IGetEmployeeListQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IGetBenefitsDataQuery _getBenefitsDataQuery;

        public GetEmployeeListQuery(IDatabaseService databaseService, IGetBenefitsDataQuery getBenefitsDataQuery)
        {
            _databaseService = databaseService;
            _getBenefitsDataQuery = getBenefitsDataQuery;
        }

        List<EmployeeModel> IGetEmployeeListQuery.Execute()
        {
            var employees = _databaseService
                .Employees
                .Include("Dependents")
                .ToList();

            var databaseServiceBenefitsData = _getBenefitsDataQuery.Execute();

            return employees
                .Select(employee => EmployeeConverter.CreateEmployeeModel(employee, databaseServiceBenefitsData))
                .ToList();
        }
    }
}