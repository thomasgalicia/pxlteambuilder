using PxlTeambuilderApi.Data;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Bootstrap
{
    public class DatabaseSeeder
    {

        public static void SeedDatabase(bool doSeed)
        {
            if (doSeed)
            {
                PxlTeamBuilderContext context = new PxlTeamBuilderContext();
                ClearDatabase(context);

                context.Users.Add(new User
                {
                    Name = "thomas",
                    Email = "thomas@student.pxl.be",
                    Role = UserRole.Student,
                    Password = "thomas"
                });
                context.Users.Add(new User
                {
                    Name = "lukas",
                    Email = "lukas@student.pxl.be",
                    Role = UserRole.Student,
                    Password = "lukas"
                });
                context.Users.Add(new User
                {
                    Name = "ahmet",
                    Email = "ahmet@student.pxl.be",
                    Role = UserRole.Student,
                    Password = "ahmet"
                });
                context.Users.Add(new User
                {
                    Name = "sergey",
                    Email = "sergey@student.pxl.be",
                    Role = UserRole.Student,
                    Password = "sergey"
                });
                context.Users.Add(new User
                {
                    Name = "kris",
                    Email = "kris@student.pxl.be",
                    Role = UserRole.Student,
                    Password = "kris"
                });
                context.SaveChanges();
            }
        }

        private static void ClearDatabase(PxlTeamBuilderContext context)
        {
            IEnumerable<User> users = context.Users.ToList();
            IEnumerable<Project> projects = context.Projects.ToList();
            IEnumerable<Group> groups = context.Groups.ToList();
            IEnumerable<UserGroup> userGroups = context.UserGroups.ToList();
            IEnumerable<UserProject> userProjects = context.UserProjects.ToList();

            context.RemoveRange(users);
            context.RemoveRange(projects);
            context.RemoveRange(groups);
            context.RemoveRange(userGroups);
            context.RemoveRange(userProjects);
            context.SaveChanges();
        }
    }
}
