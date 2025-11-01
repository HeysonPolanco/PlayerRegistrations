using System.Net.Http;
using System.Net.Http.Json;
using PlayerRegistrations.Models;

namespace PlayerRegistrations.Services;

public class MovementsServices
{
    private readonly HttpClient _http;

    public MovementsServices(HttpClient http)
    {
        _http = http;
    }

    public async Task<bool> Save(Movements movement)
    {
        var response = await _http.PostAsJsonAsync("api/Movements", movement);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<Movements>> GetByMatchIdAsync(int partidaId)
    {
        return await _http.GetFromJsonAsync<List<Movements>>($"api/Movements/{partidaId}")
               ?? new List<Movements>();
    }
}
