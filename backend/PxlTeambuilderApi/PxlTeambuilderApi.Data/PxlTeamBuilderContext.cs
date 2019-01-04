using Microsoft.EntityFrameworkCore;
using PxlTeambuilderApi.Data.Domain;

namespace PxlTeambuilderApi.Data
{
    public class PxlTeamBuilderContext : DbContext
    {

        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = PxlTeambuilderDb; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user table
            modelBuilder.Entity<User>().HasKey(user => user.Email);

            //project table
            modelBuilder.Entity<Project>().HasKey(project => project.ProjectId);
            modelBuilder.Entity<Project>().HasMany(project => project.Groups).WithOne(group => group.Project).HasForeignKey(group => group.ProjectId);

            //many to many relationships
            modelBuilder.Entity<UserGroup>().HasKey(userGroup => new { userGroup.Email, userGroup.GroupId });
            modelBuilder.Entity<UserGroup>().HasOne(userGroup => userGroup.User).WithMany(user => user.UserGroups).HasForeignKey(userGroup => userGroup.Email);
            modelBuilder.Entity<UserGroup>().HasOne(userGroup => userGroup.Group).WithMany(group => group.UserGroups).HasForeignKey(userGroup => userGroup.GroupId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
