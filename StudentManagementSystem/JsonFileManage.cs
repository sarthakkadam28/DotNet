using System;
using System.Text.Json;
using SchoolApp;
public class JsonFileManage
{
    public void Serialize(Student student, string filename)
    {
        string JsonString = JsonSerializer.Serialize(student);
        System.IO.File.WriteAllText(filename, JsonString);

    }
    public Student Deserialize(string filename)
    {
        string JsonString = System.IO.File.ReadAllText(filename);
        Student student = JsonSerializer.Deserialize<Student>(JsonString);
        return student;
    }
    
}