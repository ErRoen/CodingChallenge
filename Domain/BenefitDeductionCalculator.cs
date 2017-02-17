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
            return _benefitsData.GrossWagesPerPayPeriod
                   - CalculateDeductionForEmployee()
                   - CalculateDeductionForDependents();
        }

        private decimal CalculateDeductionForEmployee()
        {
            return CaculateDeduction(_employee, _benefitsData.AnnualBenefitCostForEmployee);
        }

        private decimal CalculateDeductionForDependents()
        {
            return _employee
                .Dependents
                .Sum(d => CaculateDeduction(d, _benefitsData.AnnualBenefitCostForDependent));
        }

        private decimal CaculateDeduction(IPerson person, decimal annualBenefitCost)
        {
            return annualBenefitCost
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