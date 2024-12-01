namespace jadwal_sholat_blazor.Models
{
    public class ApiResponse
    {
        public bool Status { get; set; }
        public object Request { get; set; }
        public List<Kota> Data { get; set; }
    }

    public class Kota
    {
        public string Id { get; set; }
        public string Lokasi { get; set; }
    }

}
