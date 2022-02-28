using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using AngularDemo.Models.StateExclusions;

namespace AngularDemo.Data
{
    public partial class StateExclusionsContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IHttpContextAccessor httpAccessor;

        public StateExclusionsContext(IHttpContextAccessor httpAccessor, DbContextOptions<StateExclusionsContext> options):base(options)
        {
            this.httpAccessor = httpAccessor;
        }

        public StateExclusionsContext(IHttpContextAccessor httpAccessor)
        {
            this.httpAccessor = httpAccessor;
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclExclusionDate>()
                  .HasOne(i => i.StateExclExclusion)
                  .WithMany(i => i.StateExclExclusionDates)
                  .HasForeignKey(i => i.StateExcl_ExclusionId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<AngularDemo.Models.StateExclusions.StateExclStateExclusion>()
                  .HasOne(i => i.StateExclState)
                  .WithMany(i => i.StateExclStateExclusions)
                  .HasForeignKey(i => i.StateExcl_StateId)
                  .HasPrincipalKey(i => i.Id);
            builder.Entity<AngularDemo.Models.StateExclusions.StateExclStateExclusion>()
                  .HasOne(i => i.StateExclExclusion)
                  .WithMany(i => i.StateExclStateExclusions)
                  .HasForeignKey(i => i.StateExcl_ExclusionId)
                  .HasPrincipalKey(i => i.Id);


            builder.Entity<AngularDemo.Models.StateExclusions.StateExclExclusionDate>()
                  .Property(p => p.ExclusionDate)
                  .HasColumnType("datetime");

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclusionView>()
                  .Property(p => p.ExclusionDate)
                  .HasColumnType("datetime");

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclExclusion>()
                  .Property(p => p.Id)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclExclusionDate>()
                  .Property(p => p.Id)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclExclusionDate>()
                  .Property(p => p.StateExcl_ExclusionId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclState>()
                  .Property(p => p.Id)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclStateExclusion>()
                  .Property(p => p.Id)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclStateExclusion>()
                  .Property(p => p.StateExcl_StateId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclStateExclusion>()
                  .Property(p => p.StateExcl_ExclusionId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclusionView>()
                  .Property(p => p.StateExclusionId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclusionView>()
                  .Property(p => p.StateId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclusionView>()
                  .Property(p => p.ExclusionId)
                  .HasPrecision(10, 0);

            builder.Entity<AngularDemo.Models.StateExclusions.StateExclusionView>()
                  .Property(p => p.ExclusionDateId)
                  .HasPrecision(10, 0);
            this.OnModelBuilding(builder);
        }


        public DbSet<AngularDemo.Models.StateExclusions.StateExclExclusion> StateExclExclusions
        {
          get;
          set;
        }

        public DbSet<AngularDemo.Models.StateExclusions.StateExclExclusionDate> StateExclExclusionDates
        {
          get;
          set;
        }

        public DbSet<AngularDemo.Models.StateExclusions.StateExclState> StateExclStates
        {
          get;
          set;
        }

        public DbSet<AngularDemo.Models.StateExclusions.StateExclStateExclusion> StateExclStateExclusions
        {
          get;
          set;
        }

        public DbSet<AngularDemo.Models.StateExclusions.StateExclusionView> StateExclusionViews
        {
          get;
          set;
        }
    }
}
