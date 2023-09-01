using Logbook.AppApi.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Logbook.AppApi.Data
{
    public class DataSeeder
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public DataSeeder( AppDbContext context, UserManager<ApplicationUser> userManager )
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task SeedData()
        {
            _context.Database.EnsureDeleted();
            _context.Database.Migrate();

            ApplicationUser newUser = new ApplicationUser()
            {
                FirstName = "test",
                LastName = "user",
                Email = "test@gmail.com",
                UserName = "testuser"
            };
            var create = await _userManager.CreateAsync( newUser, "Test1!" );

            if (!create.Succeeded) throw new Exception( "User not created" );

            var user = _context.Users.First();


            var projectsData = new[]
            {
                new Project ()
                {
                    UserId = user.Id,
                    Title = "Project1",
                    Content = "Desc for project 1",
                    DueDate = DateTime.Now.AddDays(5),
                    Status = ProjectStatus.NotStarted,
                },
            };

            _context.Projects.AddRange( projectsData );
            _context.SaveChanges();

            var project = _context.Projects.First();

            var logsData = new[]
            {
                new ProjectLog()
                {
                    UserId = user.Id,
                    EntryDate = DateTime.Now.AddDays(-2),
                    Title = "Log 1 for Task 1",
                    Content = "Log content for Task 1",
                    ProjectId = project.ProjectId,
                },
                new ProjectLog()
                {
                    UserId = user.Id,
                    EntryDate = DateTime.Now.AddDays(-1),
                    Title = "Log 1 for project",
                    Content = "Log content for project",
                    ProjectId = project.ProjectId,
                }
            };

            _context.Logs.AddRange( logsData );
            _context.SaveChanges();

            var tasksData = new[]
            {
                new ProjectTask()
                {
                    UserId = user.Id,
                    Title = "Task 1 for Project 1",
                    Status = Models.TaskStatus.NotStarted,
                    DueDate = DateTime.Now.AddDays(5),
                    ProjectId = project.ProjectId,
                }
            };
            _context.Tasks.AddRange( tasksData );
            _context.SaveChanges();

            var goalsData = new[]
            {
                new ProjectGoal()
                {
                    UserId = user.Id,
                    Title = "Goal 1 for Project 1",
                    Content = "Goal content for Project 1",
                    TargetCompletion = DateTime.Now.AddDays(15),
                    ProjectId = project.ProjectId,
                }
            };
            _context.Goals.AddRange( goalsData );
            _context.SaveChanges();

        }
    }
}
