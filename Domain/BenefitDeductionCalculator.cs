using System.Collections.Generic;
using System.Linq;
using CodingChallenge.Common;

namespace CodingChallenge.Domain
{
    public class BenefitDeductionCalculator
    {
        private readonly Employee _employee;
        private readonly BenefitsData _benefitsData;

        public BenefitDeductionCalculator(Employee employee, BenefitsData benefitsData)
        {
            _employee = employee;
            _benefitsData = benefitsData;
        }

        public decimal CalculatePaycheckAmount()
        {
            return _employee.GrossPaycheckAmount
                   - CalculateDeductionForEmployee()
                   - CalculateDeductionForDependents();
        }

        private decimal CalculateDeductionForEmployee()
        {
            return CaculateDeduction(_employee);
        }

        private decimal CalculateDeductionForDependents()
        {
            return _employee.Dependents.Sum(d => CaculateDeduction(d));
        }

        private decimal CaculateDeduction(IPerson person)
        {
            return person.AnnualBenefitCost 
                * CalculateDiscount(person.Name) 
                / _benefitsData.PaychecksPerYear;
        }

        private decimal CalculateDiscount(string name)
        {
            return name.BeginsWithA()
                ? 1 - _benefitsData.DiscountAmountForNameBeginningWithA
                : 1;
        }
    }
}