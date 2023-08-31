using Logbook.AppApi.Contracts.Services;

namespace Logbook.AppApi.Services
{
    public static class DependencyInjection
    {
        public static void AddLogbookServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectLogService, ProjectLogService>();
        }

    }
}
