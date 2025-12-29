using System.Text.Json;
namespace ShipmentAPI.Helpers;

public static class JsonHelper
{
    private static readonly string _filePath = "Data/Payment.json";

    // GET ALL
    public static List<T> GetAll<T>()
    {
        if (!File.Exists(_filePath))
            return new List<T>();

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }

    // GET BY ID
    public static T GetById<T>(Func<T, bool> predicate)
    {
        return GetAll<T>().FirstOrDefault(predicate);
    }

    // ADD (Create / Update)
    public static void Add<T>(T item)
    {
        var list = GetAll<T>();
        list.Add(item);
        Save(list);
    }

    // DELETE
    public static void Delete<T>(Func<T, bool> predicate)
    {
        var list = GetAll<T>();
        var item = list.FirstOrDefault(predicate);

        if (item == null)
            return;

        list.Remove(item);
        Save(list);
    }

    // SAVE
    private static void Save<T>(List<T> data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(_filePath, json);
    }
}