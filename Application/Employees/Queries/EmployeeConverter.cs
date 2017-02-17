using System.Linq;
using CodingChallenge.Application.Interfaces;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Employees.Queries
{
    public class EmployeeConverter
    {
        public static EmployeeModel CreateEmployeeModel(Employee e, BenefitsData benefitsData)
        {
            // Could use AutoMapper in larger projects to save time.
            return new EmployeeModel()
                   {
                       Id = e.Id,
                       Name = e.Name,
                       GrossPaycheck = benefitsData.GrossWagesPerPayPeriod,
                       AnnualBenefitCost = benefitsData.AnnualBenefitCostForEmployee,
                       NetPaycheck = GetPaycheckDeduction(e, benefitsData),
                       Dependents = DependentConverter
                           .CreateDependentModel(
                               e.Dependents,
                               benefitsData)
                   };
        }

        private static decimal GetPaycheckDeduction(Employee employee, BenefitsData benefitsData)
        {
            return new BenefitDeductionCalculator(
                       employee,
                       benefitsData)
                .CalculatePaycheckAmount();
        }

        public static Employee CreateEmployee(EmployeeModel employeeModel)
        {
            var dependents = employeeModel.Dependents
                .Select(d => new Dependent(d.Name))
                .ToList();

            return new Employee(employeeModel.Name)
                   {
                       Dependents = dependents
                   };
        }
    }
}