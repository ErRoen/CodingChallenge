using System.Collections.Generic;

namespace CodingChallenge.Tests.PaycheckTestContainer
{
    public interface IPerson
    {
        string Name { get; }
    }
    public class Employee : IPerson
    {
        public string Name { get; private set; }
        public decimal GrossPaycheckAmount { get; private set; }
        public List<IDependent> Dependents { get; set; }

        public Employee(string name, decimal grossPaycheckAmount)
        {
            Name = name;
            GrossPaycheckAmount = grossPaycheckAmount;
            Dependents = new List<IDependent>();
        }
    }

    public interface IDependent : IPerson
    {
    }

    public class Dependent : IDependent
    {
        public string Name { get; }

        public Dependent(string name)
        {
            Name = name;
        }
    }
    
}