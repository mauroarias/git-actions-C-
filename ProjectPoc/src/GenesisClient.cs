using GenesisMock.Model;

namespace ProjectPoc;

public class GenesisClient
{
    private readonly HttpClient _httpClient;

    public GenesisClient(HttpClient httpClient, IConfiguration configuration)
    {
        var host = configuration["genesis:host"];
        var port = configuration["genesis:port"];
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri($"{host}:{port}");
    }
    
    public async Task<License?> GetUser(Guid licenseId)
    {
        var license = await _httpClient.GetFromJsonAsync<License>($"/v1/core/api/license/{licenseId}");
        return license;
    }
}