namespace codefisrt_EF.Models
{
    public class Nganh
    {
        public int IdNganh { get; set; }
        public string TenNganh { get; set; }

        public int idKhoa { get; set; }
        public Khoa Khoa { get; set; }
        public List<SinhVien> SinhVien { get; set; }
    }
}
