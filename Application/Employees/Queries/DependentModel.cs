using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Application.Employees.Queries
{
    public class DependentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal AnnualBenefitCost { get; set; }
    }
}