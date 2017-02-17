using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Application.Interfaces;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Employees.Queries
{
    public class DependentConverter
    {
        public static List<DependentModel> CreateDependentModel(ICollection<Dependent> dependents, BenefitsData benefitsData)
        {
            return dependents
                .Select(d => CreateDependentModel(d, benefitsData))
                .ToList();
        }
        public static DependentModel CreateDependentModel(Dependent d, BenefitsData benefitsData)
        {
            // Could use AutoMapper in larger projects to save time.
            return new DependentModel()
            {
                Id = d.Id,
                Name = d.Name,
                AnnualBenefitCost = benefitsData.AnnualBenefitCostForDependent
            };
        }
    }
}
