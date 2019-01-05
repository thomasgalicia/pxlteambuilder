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
        public DbSet<UserProject> UserProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user table
            modelBuilder.Entity<User>().HasKey(user => user.Id);
            

            //project table
            modelBuilder.Entity<Project>().HasKey(project => project.ProjectId);
            modelBuilder.Entity<Project>().HasMany(project => project.Groups).WithOne(group => group.Project).HasForeignKey(group => group.ProjectId);

            //Group table
            modelBuilder.Entity<Group>().HasKey(group => group.GroupId);

            //many to many relationships
            modelBuilder.Entity<UserGroup>().HasKey(userGroup => new { userGroup.UserId, userGroup.GroupId });
            modelBuilder.Entity<UserGroup>().HasOne(userGroup => userGroup.User).WithMany(user => user.UserGroups).HasForeignKey(userGroup => userGroup.UserId);
            modelBuilder.Entity<UserGroup>().HasOne(userGroup => userGroup.Group).WithMany(group => group.UserGroups).HasForeignKey(userGroup => userGroup.GroupId);

            modelBuilder.Entity<UserProject>().HasKey(userProject => new { userProject.UserId, userProject.ProjectId });
            modelBuilder.Entity<UserProject>().HasOne(userProject => userProject.User).WithMany(user => user.UserProjects).HasForeignKey(userProject => userProject.UserId);
            modelBuilder.Entity<UserProject>().HasOne(userProject => userProject.Project).WithMany(project => project.UserProjects).HasForeignKey(userProject => userProject.ProjectId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
        }
    }
}
