using System.Data.Entity;
using CodingChallenge.Application.Interfaces;
using CodingChallenge.Domain;
using CodingChallenge.Persistence.Configurations;

namespace CodingChallenge.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public IDbSet<BenefitsData> BenefitsData { get; set; }

        public IDbSet<Employee> Employees { get; set; }

        public IDbSet<Dependent> Dependents { get; set; }

        public DatabaseService() : base("EmployeeBenefitsCalculator")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new DependentConfiguration());
        }
    }
}