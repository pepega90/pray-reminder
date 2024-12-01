using jadwal_sholat_blazor.Models;
using jadwal_sholat_blazor.Services;
using Microsoft.AspNetCore.Components;

namespace jadwal_sholat_blazor.Components.Pages
{
    public partial class Home
    {
        /*
         * semua kota = https://api.myquran.com/v2/sholat/kota/semua
         * single kota = https://api.myquran.com/v2/sholat/jadwal/1632/2024-11-17
         */
        [Inject]
        public JadwalService JadwalService { get; set; }
        public string Tanggal { get; set; } = string.Empty;
        public List<Kota> ListKota { get; set; } = new List<Kota>();
        public List<Kota> FilteredKota { get; set; } = new List<Kota>();
        public JadwalData SingleJadwal { get; set; } = new JadwalData();
        public string SearchKota { get; set; } = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            Tanggal = DateTime.Now.ToShortDateString();
            ListKota = await JadwalService.GetAllKota();
            FilteredKota = ListKota;
            SingleJadwal = await JadwalService.GetDetailData();
        }

        public async Task HandleSuggestion(ChangeEventArgs e)
        {
            SearchKota = e.Value?.ToString()?.ToLower() ?? string.Empty;
            FilteredKota = ListKota.Where(kota => kota.Lokasi.ToLower().Contains(SearchKota)).ToList();
            StateHasChanged();
        }

        public async Task SelectKota(Kota selectedKota)
        {
            SingleJadwal = await JadwalService.GetDetailData(selectedKota.Id);
            SearchKota = string.Empty;
            FilteredKota = ListKota;
            StateHasChanged();
        }
    }
}
