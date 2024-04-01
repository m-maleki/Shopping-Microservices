using System.Text.Json;
using System.Net.Http.Headers;

namespace Shopping.WebApi.Entities;

public static class HttpClientExtensions
{
    public static T ConvertToObject<T>(this string response)
    {
        return JsonSerializer.Deserialize<T>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}