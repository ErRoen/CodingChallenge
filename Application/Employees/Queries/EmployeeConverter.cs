using System.Linq;
using CodingChallenge.Application.Interfaces;
using CodingChallenge.Domain;

namespace CodingChallenge.Application.Employees.Queries
{
    public class EmployeeConverter
    {
        public static EmployeeModel CreateEmployeeModel(Employee e, IDatabaseService databaseService)
        {
            // Could use AutoMapper in larger projects to save time.
            return new EmployeeModel()
                   {
                       Id = e.Id,
                       Name = e.Name,
                       GrossPaycheck = e.GrossPaycheckAmount,
                       AnnualBenefitCost = e.AnnualBenefitCost,
                       NetPaycheck = GetPaycheckDeduction(e, databaseService),
                       Dependents = DependentConverter
                           .CreateDependentModel(
                               e.Dependents,
                               databaseService)
                   };
        }

        private static decimal GetPaycheckDeduction(Employee employee, IDatabaseService databaseService)
        {
            return new BenefitDeductionCalculator(
                       employee,
                       databaseService.BenefitsData)
                .CalculatePaycheckAmount();
        }

        public static Employee CreateEmployee(EmployeeModel employeeModel, IDatabaseService databaseService)
        {
            var benefitsData = databaseService.BenefitsData;
            var grossWagesPerPayPeriod = benefitsData.GrossWagesPerPayPeriod;
            var annualBenefitCostForEmployee = benefitsData.AnnualBenefitCostForEmployee;

            var dependents = employeeModel.Dependents
                .Select(d =>
                            new Dependent(
                                d.Name,
                                benefitsData.AnnualBenefitCostForDependent))
                .ToList();

            return new Employee(
                       employeeModel.Name,
                       grossWagesPerPayPeriod,
                       annualBenefitCostForEmployee)
                   {
                       Dependents = dependents
                   };
        }
    }
}