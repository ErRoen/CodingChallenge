namespace CodingChallenge.Domain
{
    public class Dependent : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal AnnualBenefitCost { get; set; }

        public Dependent(string name, decimal annualBenefitCost)
        {
            Name = name;
            AnnualBenefitCost = annualBenefitCost;
        }
    }
}