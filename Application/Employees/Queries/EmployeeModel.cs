using System.Collections.Generic;

namespace CodingChallenge.Application.Employees.Queries
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal GrossPaycheck { get; set; }
        public decimal AnnualBenefitCost { get; set; }

        public decimal NetPaycheck { get; set; }

        public List<DependentModel> Dependents { get; set; }
    }
}
