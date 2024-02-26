using System;

class Nguoi
{
    public string Ten { get; set; }
    public string DiaChiEmail { get; set; }
    public string SoDienThoai { get; set; }

    public void HienThiThongTin()
    {
        Console.WriteLine("Ten: " + Ten);
        Console.WriteLine("Email: " + DiaChiEmail);
        Console.WriteLine("SDT: " + SoDienThoai);
    }

    public void NhapThongTin()
    {
        Console.Write("Nhap ten: ");
        Ten = Console.ReadLine();

        Console.Write("Nhap email: ");
        DiaChiEmail = Console.ReadLine();

        Console.Write("Nhap SDT: ");
        SoDienThoai = Console.ReadLine();
    }
}

class NhanVien : Nguoi
{
    public string BangCap { get; set; }

    public new void HienThiThongTin()
    {
        base.HienThiThongTin();

        Console.WriteLine("Bang cap: " + BangCap);
    }

    public new void NhapThongTin()
    {
        base.NhapThongTin();

        Console.Write("Nhap bang cap: ");
        BangCap = Console.ReadLine();
    }
}

class KhachHang : Nguoi
{
    public string LoaiKhachHang { get; set; }

    public new void HienThiThongTin()
    {
        base.HienThiThongTin();

        Console.WriteLine("Loai KH: " + LoaiKhachHang);
    }

    public new void NhapThongTin()
    {
        base.NhapThongTin();

        Console.Write("Nhap loai KH: ");
        LoaiKhachHang = Console.ReadLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ban muon nhap thong tin:");
        Console.WriteLine("1. Nhan vien");
        Console.WriteLine("2. Khach hang");
        Console.Write("Toi muon nhap: ");
        
        int luaChon = Convert.ToInt32(Console.ReadLine());

        Console.Write("Nhap so luong: ");
        int soLuong = Convert.ToInt32(Console.ReadLine());

        if (luaChon == 1)
        {
            NhanVien[] nhanVienArr = new NhanVien[soLuong];
            for (int i = 0; i < soLuong; i++)
            {
                Console.WriteLine("Nhap nhan vien thu " + (i + 1) + ":");
                nhanVienArr[i] = new NhanVien();
                nhanVienArr[i].NhapThongTin();
            }

            Console.WriteLine("\n Thong tin nhan vien:");
            for (int i = 0; i < soLuong; i++)
            {
                Console.WriteLine("Nhan vien thu " + (i + 1) + ":");
                nhanVienArr[i].HienThiThongTin();
                Console.WriteLine();
            }
        }
        else if (luaChon == 2)
        {
            KhachHang[] khachHangArr = new KhachHang[soLuong];
            for (int i = 0; i < soLuong; i++)
            {
                Console.WriteLine("Nhap khach hang thu " + (i + 1) + ":");
                khachHangArr[i] = new KhachHang();
                khachHangArr[i].NhapThongTin();
            }

            Console.WriteLine("\n Thong tin khach hang:");
            for (int i = 0; i < soLuong; i++)
            {
                Console.WriteLine("Khach hang thu " + (i + 1) + ":");
                khachHangArr[i].HienThiThongTin();
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Lựa chọn không hợp lệ!");
        }

        Console.ReadLine();
    }
}