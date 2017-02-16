using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Application.Interfaces;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Employees.Queries
{
    public class DependentConverter
    {
        public static List<DependentModel> CreateDependentModel(List<Dependent> dependents, IDatabaseService databaseService)
        {
            return dependents
                .Select(d => CreateDependentModel(d, databaseService))
                .ToList();
        }
        public static DependentModel CreateDependentModel(Dependent d, IDatabaseService databaseService)
        {
            // Could use AutoMapper in larger projects to save time.
            return new DependentModel()
            {
                Id = d.Id,
                Name = d.Name,
                AnnualBenefitCost = d.AnnualBenefitCost
            };
        }
    }
}
