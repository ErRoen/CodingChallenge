using System.Collections.Generic;

namespace CodingChallenge.Domain
{
    public class Employee : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Dependent> Dependents { get; set; }

        public Employee(string name)
        {
            Name = name;
            Dependents = new List<Dependent>();
        }

        public Employee()
        {
            
        }
    }
}