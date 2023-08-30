using Logbook.AppApi.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Logbook.AppApi.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext( DbContextOptions<AppDbContext> options ) : base( options )
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<ProjectLog> Logs { get; set; }
        public DbSet<ProjectGoal> Goals { get; set; }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            base.OnModelCreating( builder );
            builder.Entity<ProjectTask>()
                .HasOne( t => t.Project )
                .WithMany( t => t.Tasks )
                .HasForeignKey( t => t.ProjectId )
                .OnDelete( DeleteBehavior.NoAction );

            builder.Entity<ProjectGoal>()
                .HasOne( g => g.Project )
                .WithMany( p => p.Goals )
                .HasForeignKey( t => t.ProjectId )
                .OnDelete( DeleteBehavior.NoAction );

            builder.Entity<ProjectLog>()
                .HasOne( l => l.Project )
                .WithMany( l => l.Logs )
                .HasForeignKey( l => l.ProjectId )
                .OnDelete( DeleteBehavior.NoAction );
        }
    }
}
