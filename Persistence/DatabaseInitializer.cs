using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CodingChallenge.Domain;

namespace CodingChallenge.Persistence
{
    public class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseService>
    {
        // These const values seem likely to change. Could load at runtime
        protected const int GrossWagesPerPayPeriod = 2000;
        private const decimal AnnualBenefitCostForEmployee = 1000M;
        private const decimal AnnualBenefitCostForDependent = 500M;
        private const decimal PaychecksPerYear = 26M;
        private const decimal DiscountAmountForNameBeginningWithA = .1M;

        protected override void Seed(DatabaseService context)
        {
            base.Seed(context);

            CreateBenefitData(context);
            CreateEmployees(context);
        }

        private void CreateBenefitData(DatabaseService context)
        {
            context.BenefitsData.Add(
                new BenefitsData
                {
                    DiscountAmountForNameBeginningWithA = DiscountAmountForNameBeginningWithA,
                    PaychecksPerYear = PaychecksPerYear,
                    GrossWagesPerPayPeriod = GrossWagesPerPayPeriod,
                    AnnualBenefitCostForEmployee = AnnualBenefitCostForEmployee,
                    AnnualBenefitCostForDependent = AnnualBenefitCostForDependent
                });
            context.SaveChanges();
        }

        private void CreateEmployees(DatabaseService context)
        {
            context.Employees.Add(CreateEmployee("Erick", "Frances", "Christian", "Harry", "Olive"));
            context.Employees.Add(CreateEmployee("Adam", "Jamie", "Cullen", "Gavin"));
            context.Employees.Add(CreateEmployee("Zach", "Amy", "Aidan", "Finley"));

            context.SaveChanges();
        }

        private static Employee CreateEmployee(string employeeName, params string[] names)
        {
            var erick = new Employee(employeeName)
                        {
                            Dependents = CreateDependentList(names)
                        };
            return erick;
        }

        private static List<Dependent> CreateDependentList(params string[] names)
        {
            return names
                .Select(n => new Dependent(n))
                .ToList();
        }
    }
}