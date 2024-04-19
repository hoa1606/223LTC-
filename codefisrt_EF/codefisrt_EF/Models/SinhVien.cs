namespace codefisrt_EF.Models
{
    public class SinhVien
    {
        public int IdSV { get; set; }
        public string TenSV { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public int idNganh { get; set; }
        public Nganh Nganh { get; set; }
    }
}
