using Logbook.AppApi.Data.Models;

namespace Logbook.AppApi.Data
{
    public class DataSeeder
    {
        private readonly AppDbContext _context;
        public DataSeeder( AppDbContext context )
        {
            _context = context;
        }
        public void SeedData()
        {
            var user1 = "1da4997f-88ca-4907-8c89-19a2281ec1f7";
            if (_context.Projects.Any())
            {
                _context.Projects.RemoveRange( _context.Projects );
                _context.SaveChanges();
            }
            var projectsData = new[]
            {
                new Project()
                {
                    UserId = user1,
                    Title = "Test Project 1",
                    Description = "Desc for project 1",
                    DueDate = DateTime.Now.AddDays(5),
                    Status = ProjectStatus.NotStarted,

                },
            };
            _context.Projects.AddRange( projectsData );
            _context.SaveChanges();

        }
    }
}
