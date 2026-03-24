using System.Text.Json;

namespace BenjaminAdamApp;

public class BeerService
{
    private readonly HttpClient _httpClient;

    public BeerService()
    {
        // Handler qui ignore les erreurs de certificat SSL (utile en debug MAUI Windows)
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };
        _httpClient = new HttpClient(handler);
        _httpClient.Timeout = TimeSpan.FromSeconds(10);
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
    }

    public async Task<List<Beer>> GetBeersAsync()
    {
        try
        {
            var url = "https://api.sampleapis.com/beers/ale";
            var response = await _httpClient.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<List<Beer>>(content);
                if (result != null && result.Count > 0)
                    return result;
            }
        }
        catch
        {
            // Si l'API est inaccessible, on utilise les données de secours ci-dessous
        }

        // --- DONNÉES DE SECOURS (Mock Data) ---
        return new List<Beer>
        {
            new Beer { Title = "Founders Centennial IPA", Description = "$16.79", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h9d/h94/11167126519838.png" },
            new Beer { Title = "Lagunitas IPA", Description = "$8.99", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h2c/h78/8804310777886.png" },
            new Beer { Title = "Duvel Belgian Ale", Description = "$12.49", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h0c/h86/8810864082974.png" },
            new Beer { Title = "Chimay Grande Reserve Blue", Description = "$21.49", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h8a/h92/8798154031134.png" },
            new Beer { Title = "Stone Arrogant Bastard Ale", Description = "$11.49", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h7a/h9c/11770097860638.png" },
            new Beer { Title = "Delirium Tremens", Description = "$18.99", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h05/ha0/8804687970334.png" },
            new Beer { Title = "Dogfish Head 60-Minute IPA", Description = "$19.99", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/h5f/h00/10124016648222.png" },
            new Beer { Title = "Kona Big Wave Golden Ale", Description = "$7.99", ImageUrl = "https://www.totalwine.com/media/sys_master/twmmedia/hb9/h8e/8797338894366.png" },
        };
    }
}
