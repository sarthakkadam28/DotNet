namespace usermangement.Entities.UserRoleWithProjectAssignment;
public class ProjectAssignment
{
    public int AssignmentId { get; set; }
    public int userId { get; set; }
    public int ProjectId { get; set; }
    public string Role{ get; set; }
}