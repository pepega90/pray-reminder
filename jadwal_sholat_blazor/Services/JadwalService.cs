using jadwal_sholat_blazor.Models;
using System.Text.Json;

namespace jadwal_sholat_blazor.Services
{
    public class JadwalService
    {
        private readonly HttpClient _httpClient;
        public string apiGetAllKota = "https://api.myquran.com/v2/sholat/kota/semua";
        public string apiGetSingleJadwal = "https://api.myquran.com/v2/sholat/jadwal/";
        public JadwalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Kota>> GetAllKota()
        {
            var response = await _httpClient.GetAsync(apiGetAllKota);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var res = JsonSerializer.Deserialize<ApiResponse>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return res.Data;
        }

        public async Task<JadwalData> GetDetailData(string idKotak = "1301")
        {
            DateTime today = DateTime.Now;
            string formattedDate = today.ToString("yyyy-MM-dd");
            var response = await _httpClient.GetAsync(apiGetSingleJadwal + $"/{idKotak}/{formattedDate}");
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var res = JsonSerializer.Deserialize<ApiResponseJadwal>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return res.Data;
        }
    }
}
