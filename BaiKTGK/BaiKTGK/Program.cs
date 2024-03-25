using System;
using System.Collections.Generic;

public class DanhMuc
{
    public DanhMuc(int idDM, string cateName)
    {
        this.IdDM = idDM;
        this.CateName = cateName;
    }

    public int IdDM { get; set; }
    public string CateName { get; set; }
}

public class TaiLieu
{
    public TaiLieu(int maXB, string tenTL, string nhaPH, DanhMuc idDM)
    {
        this.MaXB = maXB;
        this.TenTL = tenTL;
        this.NhaPH = nhaPH;
        this.IdDM = idDM;
    }

    public int MaXB { get; set; }
    public string TenTL { get; set; }
    public string NhaPH { get; set; }
    public DanhMuc IdDM { get; set; }
}

public class Bao : TaiLieu
{
    public Bao(int maXB, string tenTL, string nhaPH, DateTime ngayPH, DanhMuc idDM) : base(maXB, tenTL, nhaPH, idDM)
    {
        this.NgayPH = ngayPH;
    }

    public DateTime NgayPH { get; set; }
}

public class Sach : TaiLieu
{
    public Sach(int maXB, string tenTL, string nhaPH, int soTrang, string tenTG, DanhMuc idDM) : base(maXB, tenTL, nhaPH, idDM)
    {
        this.SoTrang = soTrang;
        this.TenTG = tenTG;
    }

    public string TenTG { get; set; }
    public int SoTrang { get; set; }
}

public class TapChi : TaiLieu
{
    public TapChi(int maXB, string tenTL, string nhaPH, int soPH, int trangPH, DanhMuc idDM) : base(maXB, tenTL, nhaPH, idDM)
    {
        this.SoPH = soPH;
        this.TrangPH = trangPH;
    }

    public int SoPH { get; set; }
    public int TrangPH { get; set; }
}

class Program
{
    public static void Main(string[] args)
    {
        List<DanhMuc> danhMuc144 = new List<DanhMuc>
        {
            new DanhMuc(1, "sach"),
            new DanhMuc(2, "bao"),
            new DanhMuc(3, "tap chi")
        };
        List<Sach> sach144 = new List<Sach>
        {
            new Sach(1, "Toan", "NXB Kim Dong", 100, "nhieu nguoi", danhMuc144[0]),
            new Sach(2, "Ly", "NXB Kim Dong", 100, "nhieu nguoi", danhMuc144[0]),
            new Sach(3, "Hoa", "NXB Kim Dong", 100, "nhieu nguoi", danhMuc144[0])
        };
        List<Bao> bao144 = new List<Bao>
        {
            new Bao(1, "Động đất ở Mỹ Đức, nội thành Hà Nội rung lắc", "VNexpress", new DateTime(2024, 03, 25), danhMuc144[1]),
            new Bao(2, "Động đất ở Mỹ Đức, nội thành Hà Nội rung lắc", "Thanh Nien", new DateTime(2024, 02, 25), danhMuc144[1]),
            new Bao(3, "Động đất ở Mỹ Đức, nội thành Hà Nội rung lắc", "Lao dong", new DateTime(2024, 03, 21), danhMuc144[1])
        };
        List<TapChi> tapChi144 = new List<TapChi>
        {
            new TapChi(1, "Tạp chí Khoa học và Công nghệ Việt Nam", "vjol", 5, 1, danhMuc144[2]),
            new TapChi(2, "Tạp chí Khoa học và Công nghệ Việt Nam", "vjol", 7, 1, danhMuc144[2]),
            new TapChi(3, "Tạp chí Khoa học và Công nghệ Việt Nam", "vjol", 6, 5, danhMuc144[2])
        };

        // Tìm kiếm theo loại
        var sachResult144 = sach144.Where(s => s.GetType() == typeof(Sach)).ToList();
        Console.WriteLine("\nThông tin sách:");
        foreach (var item in sachResult144)
        {
            Console.WriteLine($"Ma XB: {item.MaXB}, Ten TL: {item.TenTL}, Nha PH: {item.NhaPH}, So trang: {item.SoTrang}, Ten tac gia: {item.TenTG}");
        }

        
        var baoResult144 = bao144.Where(b => b.GetType() == typeof(Bao)).ToList();
        Console.WriteLine("\nThông tin báo:");
        foreach (var item in baoResult144)
        {
            Console.WriteLine($"Ma XB: {item.MaXB}, Ten TL: {item.TenTL}, Nha PH: {item.NhaPH}, Ngay phat hanh: {item.NgayPH}");
        }

        
        var tapChiResult144 = tapChi144.Where(tc => tc.GetType() == typeof(TapChi)).ToList();
        Console.WriteLine("\nThông tin tạp chí:");
        foreach (var item in tapChiResult144)
        {
            Console.WriteLine($"Ma XB: {item.MaXB}, Ten TL: {item.TenTL}, Nha PH: {item.NhaPH}, So phat hanh: {item.SoPH}, So trang phat hanh: {item.TrangPH}");
        }

        //Tìm báo có ngày phát hành trong tháng 3/2024
        var baoT3_144 = bao144.Where(b => b.NgayPH.Month ==3 && b.NgayPH.Year == 2024);
        Console.WriteLine("\nThông tin báo phát hành trong tháng 3:");
        foreach (var item in baoT3_144)
        {
            Console.WriteLine($"Ma XB: {item.MaXB}, Ten TL: {item.TenTL}, Nha phat hanh: {item.NhaPH}, Ngay phat hanh: {item.NgayPH.ToString("dd/MM/yyyy")}");
        }
    }
}
