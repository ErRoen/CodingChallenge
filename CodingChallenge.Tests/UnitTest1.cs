using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingChallenge.Tests.PaycheckTestContainer
{
    [TestClass]
    public class PaycheckTests
    {
        protected const int GrossWagesPerPayPeriod = 2000;

        [TestClass]
        public class PaycheckAmountMethod : PaycheckTests
        {
            private static void BaseTest(Employee employee, decimal amount)
            {
                var something = new Something(employee);
                var paycheckAmount = something.GetPaycheckAmount();

                var expected = new Currency(amount).Amount;
                var actual = new Currency(paycheckAmount).Amount;

                Assert.AreEqual(expected, actual);
            }

            [TestMethod]
            public void EmployeeSolo()
            {
                const decimal amount = 1961.538461538462M;
                var employee = new Employee("Erick", GrossWagesPerPayPeriod);

                BaseTest(employee, amount);
            }

            [TestMethod]
            public void EmployeeSoloWithAName()
            {
                const decimal amount = 1965.384615384615M;
                var employee = new Employee("Atticus", GrossWagesPerPayPeriod);

                BaseTest(employee, amount);
            }
        }
    }

    public class Something
    {
        private const decimal BaseBenefitDeductionAmountPerYear = 1000M;
        private const decimal NumberOfPaychecksPerYear = 26M;
        private const decimal DiscountAmountForNameBeginningWithA = .1M;

        private readonly Employee _employee;

        public Something(Employee employee)
        {
            _employee = employee;
        }

        public decimal GetPaycheckAmount()
        {
            return _employee.GrossPaycheckAmount - GetCostOfBenefitsPerPaycheck();
        }

        private decimal GetCostOfBenefitsPerPaycheck()
        {
            var discountMultiplier = _employee.Name.StartsWith("a",StringComparison.CurrentCultureIgnoreCase) 
                ? 1 - DiscountAmountForNameBeginningWithA 
                : 1;

            return BaseBenefitDeductionAmountPerYear * discountMultiplier / NumberOfPaychecksPerYear;
        }
    }
}