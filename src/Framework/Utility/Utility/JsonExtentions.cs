using System.Text.Json;

namespace Utility;
public static class JsonExtentions
{
    public static T ConvertToObject<T>(this string response)
    {
        return JsonSerializer.Deserialize<T>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}