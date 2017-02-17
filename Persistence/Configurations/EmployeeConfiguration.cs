using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingChallenge.Domain;

namespace CodingChallenge.Persistence.Configurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(e => e.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
    public class DependentConfiguration : EntityTypeConfiguration<Dependent>
    {
        public DependentConfiguration()
        {
            HasKey(e => e.Id);

            HasRequired(p => p.Employee);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
