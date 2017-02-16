using System.Collections.Generic;

namespace CodingChallenge.Application.Employees.Queries
{
    public interface IGetEmployeeListQuery
    {
        List<EmployeeModel> Execute();
    }
}