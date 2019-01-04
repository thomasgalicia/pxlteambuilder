using Microsoft.EntityFrameworkCore;
using PxlTeambuilderApi.Data.Domain;

namespace PxlTeambuilderApi.Data
{
    public class PxlTeamBuilderContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserProjects> UserProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user table
            modelBuilder.Entity<User>().HasKey(user => user.Email);

            //project table
            modelBuilder.Entity<Project>().HasKey(project => project.ProjectId);

            //many to many relationship
            modelBuilder.Entity<UserProjects>().HasKey(userProject => new { userProject.Email, userProject.ProjectId });
            modelBuilder.Entity<UserProjects>().HasOne(userProject => userProject.User).WithMany(user => user.UserProjects).HasForeignKey(userProject => userProject.Email);
            modelBuilder.Entity<UserProjects>().HasOne(userProject => userProject.Project).WithMany(project => project.UserProjects).HasForeignKey(userProject => userProject.ProjectId);
        }

    }
}
