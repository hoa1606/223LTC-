namespace codefisrt_EF.Models
{
    public class Khoa
    {
        public int IdKhoa { get; set; }
        public string TenKhoa { get; set; }
        public List<Nganh> Nganh { get; set; }
    }
}
