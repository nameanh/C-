using System;
using System.Collections.Generic;

public class NhanVienPB
{
    public string HoTen { get; set; } = "";
    public double MucLuong { get; set; }
    public int SoNgayVang { get; set; }

    public void Nhap()
    {
        Console.Write("Họ tên: "); HoTen = Console.ReadLine() ?? "";
        Console.Write("Mức lương cơ bản: "); MucLuong = double.Parse(Console.ReadLine()!);
        Console.Write("Số ngày vắng: "); SoNgayVang = int.Parse(Console.ReadLine()!);
    }

    // Mỗi ngày vắng bị trừ 100.000 VNĐ
    public double TinhLuongThucNhan()
    {
        double luong = MucLuong - (SoNgayVang * 100000);
        return luong < 0 ? 0 : luong;
    }
}

public class PhongBan
{
    private List<NhanVienPB> ds = new List<NhanVienPB>();

    public void Nhap()
    {
        Console.Write("Nhập số lượng nhân viên trong phòng ban: ");
        int n = int.Parse(Console.ReadLine()!);
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nNhập nhân viên thứ {i + 1}:");
            NhanVienPB nv = new NhanVienPB();
            nv.Nhap();
            ds.Add(nv);
        }
    }

    public double TongLuongPhongBan()
    {
        double tong = 0;
        foreach (var nv in ds) tong += nv.TinhLuongThucNhan();
        return tong;
    }
}

public class Bai2_5
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        PhongBan pb = new PhongBan();
        pb.Nhap();
        Console.WriteLine($"\n==> TỔNG LƯƠNG PHÒNG BAN: {pb.TongLuongPhongBan():N0} VNĐ");
    }
}