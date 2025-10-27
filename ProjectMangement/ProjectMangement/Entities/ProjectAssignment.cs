namespace ProjectMangement.Entities;
public class ProjectAssignment
{
    public int AssignmentId { get; set; }
    public int UserId { get; set; }
    public int ProjectId { get; set; }
    public string Role{ get; set; }
}