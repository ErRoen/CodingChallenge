using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Application.Interfaces;
using CodingChallenge.Domain;

namespace CodingChallenge.Persistence
{
    public class DatabaseService : IDatabaseService
    {
        // These const values seem likely to change. Could load at runtime
        protected const int GrossWagesPerPayPeriod = 2000;
        private const decimal AnnualBenefitCostForEmployee = 1000M;
        private const decimal AnnualBenefitCostForDependent = 500M;
        private const decimal PaychecksPerYear = 26M;
        private const decimal DiscountAmountForNameBeginningWithA = .1M;

        public BenefitsData BenefitsData { get; set; }

        public List<Employee> Employees { get; set; }

        public DatabaseService()
        {
            BenefitsData = CreateBenefitsData();
            Employees = CreateEmployees();
        }

        private static BenefitsData CreateBenefitsData()
        {
            return new BenefitsData
            {
                DiscountAmountForNameBeginningWithA = DiscountAmountForNameBeginningWithA,
                PaychecksPerYear = PaychecksPerYear,
                GrossWagesPerPayPeriod = GrossWagesPerPayPeriod,
                AnnualBenefitCostForEmployee = AnnualBenefitCostForEmployee,
                AnnualBenefitCostForDependent = AnnualBenefitCostForDependent
            };
        }

        private List<Employee> CreateEmployees()
        {
            return new List<Employee>
                   {
                       new Employee("Erick", GrossWagesPerPayPeriod, AnnualBenefitCostForEmployee)
                       {
                           Id = 1,
                           Dependents = CreateDependentList("Frances", "Christian", "Harry", "Olive")
                       },
                       new Employee("Adam", GrossWagesPerPayPeriod, AnnualBenefitCostForEmployee)
                       {
                           Id = 2,
                           Dependents = CreateDependentList("Jamie", "Cullen", "Gavin")
                       },
                       new Employee("Zach", GrossWagesPerPayPeriod, AnnualBenefitCostForEmployee)
                       {
                           Id = 3,
                           Dependents = CreateDependentList("Amy", "Aidan", "Finley")
                       }
                   };
        }

        private static List<Dependent> CreateDependentList(params string[] names)
        {
            return names
                .Select(name => new Dependent(name, AnnualBenefitCostForDependent))
                .ToList();
        }

    }
}