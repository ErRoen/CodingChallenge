using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Application.Employees.Queries
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal GrossPaycheck { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal AnnualBenefitCost { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal NetPaycheck { get; set; }

        public List<DependentModel> Dependents { get; set; }
    }
}
