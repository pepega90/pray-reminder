namespace jadwal_sholat_blazor.Models
{
    public class ApiResponseJadwal
    {
        public bool Status { get; set; }
        public RequestInfo Request { get; set; }
        public JadwalData Data { get; set; }
    }

    public class RequestInfo
    {
        public string Path { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }
    }

    public class JadwalData
    {
        public int Id { get; set; }
        public string Lokasi { get; set; }
        public string Daerah { get; set; }
        public Jadwal Jadwal { get; set; }
    }

    public class Jadwal
    {
        public string Tanggal { get; set; }
        public string Imsak { get; set; }
        public string Subuh { get; set; }
        public string Terbit { get; set; }
        public string Dhuha { get; set; }
        public string Dzuhur { get; set; }
        public string Ashar { get; set; }
        public string Maghrib { get; set; }
        public string Isya { get; set; }
        public string Date { get; set; }
    }

}
