using System.Collections.Generic;
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

        List<Employee> IGetEmployeeListQuery.Execute()
        {
            return _databaseService.Employees;
        }
    }
}