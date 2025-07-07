
using System;
using System.Text.Json;


using Assesment.Entities;


namespace Persistance;

public class JsonFileManager
{

    public void Serialize(List<Question> questions, string fileName)
    {
        var options = new JsonSerializerOptions { IncludeFields = true };
        var questionsJson = JsonSerializer.Serialize(questions, options);
        File.WriteAllText(fileName, questionsJson);
    }

    public List<Question> DeSerialize(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);
        List<Question> questions = JsonSerializer.Deserialize<List<Question>>(jsonString);
        return questions;
    }
}

    