﻿namespace CodingChallenge.Domain
{
    public class BenefitsData
    {
        public int Id { get; set; }

        public decimal PaychecksPerYear { get; set; }

        public decimal DiscountAmountForNameBeginningWithA { get; set; }

        public int GrossWagesPerPayPeriod { get; set; }

        public decimal AnnualBenefitCostForEmployee { get; set; }

        public decimal AnnualBenefitCostForDependent { get; set; }
    }
}