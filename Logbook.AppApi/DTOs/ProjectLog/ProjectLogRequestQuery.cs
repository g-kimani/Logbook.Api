namespace Logbook.AppApi.DTOs.ProjectLog
{
    public class ProjectLogRequestQuery
    {
        public string SortBy { get; set; } = "entryDate";
        public string Order { get; set; } = "desc";
    }
}
