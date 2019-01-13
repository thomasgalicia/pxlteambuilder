using Microsoft.EntityFrameworkCore;
using PxlTeambuilderApi.Data.Domain;

namespace PxlTeambuilderApi.Data
{
    public class PxlTeamBuilderContext : DbContext
    {

        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PxlTeamBuilderDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserProjectDetail> UserProjectDetails { get; set; }
       /* public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //user table
            modelBuilder.Entity<User>().HasKey(user => user.Id);
            modelBuilder.Entity<User>().HasMany(user => user.CreatedProjects).WithOne(project => project.Creator).HasForeignKey(project => project.UserId).OnDelete(DeleteBehavior.Cascade);

            //project table
            modelBuilder.Entity<Project>().HasKey(project => project.ProjectId);
            //modelBuilder.Entity<Project>().HasOne(project => project.Creator).WithMany(user => user.CreatedProjects).HasForeignKey(project => project.UserId).OnDelete(DeleteBehavior.Cascade);

            //Group table
            modelBuilder.Entity<Group>().HasKey(group => group.GroupId);
            modelBuilder.Entity<Group>().Ignore(group => group.TeamMembers);
            modelBuilder.Entity<Group>().HasOne(group => group.Project).WithMany(project => project.Groups).HasForeignKey(group => group.ProjectId).OnDelete(DeleteBehavior.Cascade);

            //many to many relationships
            modelBuilder.Entity<UserProjectDetail>().HasKey(userProjectDetail => new { userProjectDetail.UserId, userProjectDetail.ProjectId });
            modelBuilder.Entity<UserProjectDetail>().HasOne(userProjectDetail => userProjectDetail.User).WithMany(user => user.UserProjectDetails).HasForeignKey(userProjectDetail => userProjectDetail.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserProjectDetail>().HasOne(userProjectDetail => userProjectDetail.Project).WithMany(project => project.UserProjectDetails).HasForeignKey(userProjectDetail => userProjectDetail.ProjectId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserProjectDetail>().HasOne(userProjectDetail => userProjectDetail.Group).WithMany(group => group.UserProjectDetails).HasForeignKey(userProjectDetail => userProjectDetail.GroupId).OnDelete(DeleteBehavior.Restrict);
            /*modelBuilder.Entity<UserGroup>().HasKey(userGroup => new { userGroup.UserId, userGroup.GroupId });
            modelBuilder.Entity<UserGroup>().HasOne(userGroup => userGroup.User).WithMany(user => user.UserGroups).HasForeignKey(userGroup => userGroup.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserGroup>().HasOne(userGroup => userGroup.Group).WithMany(group => group.UserGroups).HasForeignKey(userGroup => userGroup.GroupId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserProject>().HasKey(userProject => new { userProject.UserId, userProject.ProjectId });
            modelBuilder.Entity<UserProject>().HasOne(userProject => userProject.User).WithMany(user => user.UserProjects).HasForeignKey(userProject => userProject.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserProject>().HasOne(userProject => userProject.Project).WithMany(project => project.UserProjects).HasForeignKey(userProject => userProject.ProjectId).OnDelete(DeleteBehavior.Cascade);*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
        }
    }
}
