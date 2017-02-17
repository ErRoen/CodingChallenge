using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<BenefitsData> BenefitsData { get; set; }

        IDbSet<Employee> Employees { get; set; }

        IDbSet<Dependent> Dependents { get; set; }

        void Save();
    }
}