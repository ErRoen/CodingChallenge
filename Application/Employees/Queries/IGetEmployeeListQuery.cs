using System;
using System.Collections.Generic;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Employees.Queries
{
    public interface IGetEmployeeListQuery
    {
        List<Employee> Execute();
    }
}