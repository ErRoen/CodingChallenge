using System.Collections.Generic;

namespace CodingChallenge.Domain
{
    public class Employee : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal GrossPaycheckAmount { get; private set; }
        public decimal AnnualBenefitCost { get; set; }
        public List<Dependent> Dependents { get; set; }

        public Employee(string name, decimal grossPaycheckAmount, decimal annualBenefitCost)
        {
            Name = name;
            GrossPaycheckAmount = grossPaycheckAmount;
            AnnualBenefitCost = annualBenefitCost;
            Dependents = new List<Dependent>();
        }
    }
}