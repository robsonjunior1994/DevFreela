using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
               .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Frelancer)
                .WithMany(f => f.FrelanceProjects)
                .HasForeignKey(f => f.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Client)
                .WithMany(f => f.OwnedProjects)
                .HasForeignKey(f => f.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
