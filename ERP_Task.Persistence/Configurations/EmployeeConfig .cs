using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP_Task.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ERP_Task.Persistence.Configurations
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Email).IsRequired();
            builder.HasOne(e => e.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(e => e.DepartmentId);
        }
    }

}
