using System.Collections.Generic;
using CodingChallenge.Common;
using CodingChallenge.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingChallenge.Tests.PaycheckTestContainer
{
    [TestClass]
    public class PaycheckTests
    {
        // These const values seem likely to change. Could load at runtime
        protected const int GrossWagesPerPayPeriod = 2000;
        private const decimal AnnualBenefitCostForEmployee = 1000M;
        private const decimal AnnualBenefitCostForDependent = 500M;
        private const decimal PaychecksPerYear = 26M;
        private const decimal DiscountAmountForNameBeginningWithA = .1M;


        private static void BaseTest(Employee employee, decimal amount)
        {
            var paycheckAmount = GetBenefitDeductionCalculator(employee)
                .CalculatePaycheckAmount();

            var expected = new Money(amount).Amount;
            var actual = new Money(paycheckAmount).Amount;

            Assert.AreEqual(expected, actual);
        }

        private static BenefitDeductionCalculator GetBenefitDeductionCalculator(Employee employee)
        {
            var benefitsData = new BenefitsData
                               {
                                   DiscountAmountForNameBeginningWithA = DiscountAmountForNameBeginningWithA,
                                   PaychecksPerYear = PaychecksPerYear
                               };
            var benefitDeductionCalculator = new BenefitDeductionCalculator(employee, benefitsData);
            return benefitDeductionCalculator;
        }

        private Employee CreateEmployee(string name)
        {
            return new Employee(
                name,
                GrossWagesPerPayPeriod,
                AnnualBenefitCostForEmployee);
        }

        private Dependent CreateDependent(string name)
        {
            return new Dependent(
                name,
                AnnualBenefitCostForDependent);
        }

        private void AddMultipleEmployees(Employee employee)
        {
            employee.Dependents.AddRange(
                new List<Dependent>
                {
                    CreateDependent("Frances"),
                    CreateDependent("Christian"),
                    CreateDependent("Harry"),
                    CreateDependent("Olive")
                });
        }

        [TestClass]
        public class PaycheckAmountMethod : PaycheckTests
        {

            [TestMethod]
            public void EmployeeSolo()
            {
                const decimal amount = 1961.538461538462M;
                var employee = CreateEmployee("Erick");

                BaseTest(employee, amount);
            }

            [TestMethod]
            public void EmployeeSoloWithAName()
            {
                const decimal amount = 1965.384615384615M;
                var employee = CreateEmployee("Arbuckle");

                BaseTest(employee, amount);
            }

            [TestMethod]
            public void EmployeeWithOneDependent()
            {
                const decimal amount = 1942.307692307693M;
                var employee = CreateEmployee("Erick");
                employee.Dependents.Add(CreateDependent("Frances"));

                BaseTest(employee, amount);
            }


            [TestMethod]
            public void EmployeeWithOneANameDependent()
            {
                const decimal amount = 1944.23076923077M;
                var employee = CreateEmployee("Erick");
                employee.Dependents.Add(CreateDependent("Arbuckle"));

                BaseTest(employee, amount);
            }

            [TestMethod]
            public void EmployeeWithManyDependents()
            {
                const decimal amount = 1884.615385M;
                var employee = CreateEmployee("Erick");

                AddMultipleEmployees(employee);

                BaseTest(employee, amount);
            }

            [TestMethod]
            public void EmployeeWithMixNamedDependents()
            {
                const decimal amount = 1867.307692M;
                var employee = CreateEmployee("Erick");
                AddMultipleEmployees(employee);
                employee.Dependents.Add(CreateDependent("Arbuckle"));

                BaseTest(employee, amount);
            }
        }
    }
}