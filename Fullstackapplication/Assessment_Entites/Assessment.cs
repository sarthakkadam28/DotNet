namespace Transflower.TFLAssessment.Entities;

public class Assesment
{
    public int Id { get; set; }
    public string TestName { get; set; }
    public int SubjectId { get; set; }
    public timeonly Duration { get; set; }
    public int SubjectExpertId { get; set; }
    public datetime CreationDate { get; set; }
    public datetime ModificationDate { get; set; }
    public datetime ScheduleDate { get; set; }
    public string Status { get; set; }
    public int PassingLevel { get; set; }
    public string Subject { get; set; }
    public string FirstName { get; set; }
    public string LastName{ get; set; }



}