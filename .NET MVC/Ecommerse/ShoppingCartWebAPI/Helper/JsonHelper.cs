using System.Text.Json;
public static class JsonHelper
{
    // public string filePath = "Data/cart.json";
    public static T LoadJson<T>(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }

    public static void SaveJson<T>(string filePath, T data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}