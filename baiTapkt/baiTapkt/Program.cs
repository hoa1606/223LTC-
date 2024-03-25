using System;
using System.Collections.Generic;
using System.Linq;

public class Khoa
{
    public Khoa(int maKhoa, string tenKhoa)
    {
        this.maKhoa = maKhoa;
        this.tenKhoa = tenKhoa;
    }

    public int maKhoa { get; set; }
    public string tenKhoa { get; set; }
}

public class Nganh
{
    public Nganh(int maNhanh, string tenNhanh, Khoa khoa)
    {
        this.maNhanh = maNhanh;
        this.tenNhanh = tenNhanh;
        this.Khoa = khoa;
    }
    public int maNhanh { get; set; }
    public string tenNhanh { get; set; }
    public Khoa Khoa { get; set; }
}

public class sinhVien
{
    public sinhVien(int maSV, string tenSV, DateTime ngaySinh, string Que, Nganh nganh)
    {
        this.maSV = maSV;
        this.tenSV = tenSV;
        this.ngaySinh = ngaySinh;
        this.Que = Que;
        this.Nganh = nganh;
    }
    public int maSV { get; set; }
    public string tenSV { get; set; }
    public DateTime ngaySinh { get; set; }
    public string Que { get; set; }
    public Nganh Nganh { get; set; }
}

class Program
{
    public static void Main(string[] args)
    {
        List<Khoa> khoa = new List<Khoa>
        {
            new Khoa(1, "Cong Nghe so"),
            new Khoa(2, "Xay Dung"),
            new Khoa(3, "Dien Dien Tu")
        };
        List<Nganh> nganh = new List<Nganh>
        {
            new Nganh(1, "Cong nghe thong tin", khoa[0]),
            new Nganh(2, "tu dong hoa", khoa[0]),
            new Nganh(3, "dien tu vien thong", khoa[2])
        };
        List<sinhVien> sinhvien = new List<sinhVien>
        {
            new sinhVien(1, "Do Huu Hoa", new DateTime(2002,06,16), "Da Nang", nganh[0]),
            new sinhVien(2, "Nguyen Dang Kieu Diem", new DateTime(2002,03,16), "Quang Nam", nganh[0]),
            new sinhVien(3, "Huynh Thij Hai Hau", new DateTime(2002,01,27), "Quang Nam", nganh[0]),
            new sinhVien(4, "Nguyen Van Viet", new DateTime(2002,01,02), "Da Nang", nganh[2]),
            new sinhVien(5, "Nguyen hoang", new DateTime(2002,10,11), "Da Nang", nganh[2])
        };

        Console.WriteLine("Nhap ten can tim: ");
        String name = Console.ReadLine();

        var timkiem = sinhvien.Where(sv => sv.tenSV.Contains(name));

        foreach (var sv in timkiem)
        {
            Console.WriteLine($"MaSV: {sv.maSV}, TenSV: {sv.tenSV}, Ngay Sinh: {sv.ngaySinh}, Que Quan: {sv.Que}, Nganh: {sv.Nganh.tenNhanh}");
        }
    }
}
