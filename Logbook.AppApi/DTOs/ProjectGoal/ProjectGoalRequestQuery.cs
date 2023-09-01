namespace Logbook.AppApi.DTOs.ProjectGoal
{
    public class ProjectGoalRequestQuery
    {
        public string SortBy { get; set; } = "created";
        public string Order { get; set; } = "desc";
    }
}
