namespace Logbook.AppApi.DTOs.ProjectTask
{
    public class ProjectTaskRequestQuery
    {
        public string SortBy { get; set; } = "duedate";
        public string Order { get; set; } = "asc";

    }
}
