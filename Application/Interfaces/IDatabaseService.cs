using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Interfaces
{
    public interface IDatabaseService
    {
        BenefitsData BenefitsData { get; set; }

        List<Employee> Employees { get; set; }
    }
}