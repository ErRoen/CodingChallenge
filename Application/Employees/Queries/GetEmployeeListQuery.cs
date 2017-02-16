using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Application.Interfaces;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Employees.Queries
{
    public class GetEmployeeListQuery : IGetEmployeeListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetEmployeeListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        List<EmployeeModel> IGetEmployeeListQuery.Execute()
        {
            return _databaseService.Employees
                .Select(e => EmployeeConverter.CreateEmployeeModel(e,_databaseService))
                .ToList();
        }
    }
}