using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using AngularDemo.Models.StateExclusionsDatabase;

namespace AngularDemo.Data
{
    public partial class StateExclusionsDatabaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IHttpContextAccessor httpAccessor;

        public StateExclusionsDatabaseContext(IHttpContextAccessor httpAccessor, DbContextOptions<StateExclusionsDatabaseContext> options):base(options)
        {
            this.httpAccessor = httpAccessor;
        }

        public StateExclusionsDatabaseContext(IHttpContextAccessor httpAccessor)
        {
            this.httpAccessor = httpAccessor;
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.ExclusionDate>()
                  .HasOne(i => i.Exclusion)
                  .WithMany(i => i.ExclusionDates)
                  .HasForeignKey(i => i.ExclusionId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.StateExclusion>()
                  .HasOne(i => i.State)
                  .WithMany(i => i.StateExclusions)
                  .HasForeignKey(i => i.StateId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.StateExclusion>()
                  .HasOne(i => i.Exclusion)
                  .WithMany(i => i.StateExclusions)
                  .HasForeignKey(i => i.ExclusionId)
                  .HasPrincipalKey(i => i.Id);


            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.ExclusionDate>()
                  .Property(p => p.Date)
                  .HasColumnType("datetime");

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.StateExclusionView>()
                  .Property(p => p.Date)
                  .HasColumnType("datetime");

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.Exclusion>()
                  .Property(p => p.Id)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.ExclusionDate>()
                  .Property(p => p.Id)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.ExclusionDate>()
                  .Property(p => p.ExclusionId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.State>()
                  .Property(p => p.Id)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.StateExclusion>()
                  .Property(p => p.Id)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.StateExclusion>()
                  .Property(p => p.StateId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.StateExclusion>()
                  .Property(p => p.ExclusionId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.StateExclusionView>()
                  .Property(p => p.StateExclusionId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.StateExclusionView>()
                  .Property(p => p.StateId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.StateExclusionView>()
                  .Property(p => p.ExclusionId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusionsDatabase.StateExclusionView>()
                  .Property(p => p.ExclusionDateId)
                  .HasPrecision(10, 0);
            this.OnModelBuilding(builder);
        }


        public DbSet<AngularDemo.Models.StateExclusionsDatabase.Exclusion> Exclusions
        {
          get;
          set;
        }

        public DbSet<AngularDemo.Models.StateExclusionsDatabase.ExclusionDate> ExclusionDates
        {
          get;
          set;
        }

        public DbSet<AngularDemo.Models.StateExclusionsDatabase.State> States
        {
          get;
          set;
        }

        public DbSet<AngularDemo.Models.StateExclusionsDatabase.StateExclusion> StateExclusions
        {
          get;
          set;
        }

        public DbSet<AngularDemo.Models.StateExclusionsDatabase.StateExclusionView> StateExclusionViews
        {
          get;
          set;
        }
    }
}
