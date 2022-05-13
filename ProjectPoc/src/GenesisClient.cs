using GenesisMock.Model;

namespace ProjectPoc;

public class GenesisClient
{
    private readonly HttpClient _httpClient;

    private GenesisClient(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }
    
    public async Task<License?> GetUser(Guid licenseId)
    {
        var license = await _httpClient.GetFromJsonAsync<License>($"/v1/core/api/license/{licenseId}");
        return license;
    }

    public static GenesisClient BuildClient(string host)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(host);
        var genesisClient = new GenesisClient(client);
        return genesisClient;
    }
}