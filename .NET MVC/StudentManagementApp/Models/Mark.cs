namespace StudentManagementApp.Models;
public class Mark
{
    public int MarkId {get;set;}
    public int StudentId {get;set;}
    public int CourseId{get;set;}
    public int MarksObtained {get;set;}

    public DateTime ExamDate{get;set;}

}