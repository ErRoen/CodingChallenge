namespace CodingChallenge.Domain
{
    public class Dependent : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Employee Employee { get; set; }

        public Dependent(string name)
        {
            Name = name;
        }

        public Dependent()
        {
            
        }
    }
}