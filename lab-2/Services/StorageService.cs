using System.Text.Json;

namespace lab_2.Services;

public static class JsonStorageService<T>
{
    public static List<T> Load(string filePath)
    {
        if (!File.Exists(filePath)) return new List<T>();

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
    }

    public static void Save(List<T> data, string filePath)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}