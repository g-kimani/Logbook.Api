using Logbook.AppApi.Data.Models;

namespace Logbook.AppApi.DTOs.Project
{
    public class ProjectRequestQuery
    {
        public string SortBy { get; set; } = "DueDate";
        public bool IsAscending { get; set; } = false;
        public ProjectStatus Status { get; set; }
    }
}
