using System;
using System.Collections.Generic;

public abstract class NhanVienCty
{
    public string MaNV { get; set; } = "";
    public string HoTen { get; set; } = "";

    public virtual void Nhap()
    {
        Console.Write("Mã NV: "); MaNV = Console.ReadLine() ?? "";
        Console.Write("Họ tên: "); HoTen = Console.ReadLine() ?? "";
    }

    public abstract double TinhLuong();

    public virtual void Xuat()
    {
        Console.WriteLine($"[{MaNV}] {HoTen} | Lương: {TinhLuong():N0} VNĐ");
    }
}

// Nhân viên kinh doanh
public class NhanVienKinhDoanh : NhanVienCty
{
    public double LuongCoBan { get; set; }
    public int SoHopDong { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Lương cơ bản: "); LuongCoBan = double.Parse(Console.ReadLine()!);
        Console.Write("Số hợp đồng ký được: "); SoHopDong = int.Parse(Console.ReadLine()!);
    }

    public override double TinhLuong() => LuongCoBan + (SoHopDong * 500000);
}

// Nhân viên sản xuất
public class NhanVienSanXuat : NhanVienCty
{
    public int SoSanPham { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Số sản phẩm: "); SoSanPham = int.Parse(Console.ReadLine()!);
    }

    public override double TinhLuong()
    {
        double luong = SoSanPham * 1000;
        if (SoSanPham > 3000) luong += luong * 0.05; // Thưởng 5%
        return luong;
    }
}

public class Bai3_5
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<NhanVienCty> ds = new List<NhanVienCty>();

        Console.Write("Nhập số lượng nhân viên: ");
        int n = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Chọn loại nhân viên thứ {i + 1} (1: Kinh doanh, 2: Sản xuất) ---");
            int loai = int.Parse(Console.ReadLine()!);
            NhanVienCty nv = loai == 1 ? new NhanVienKinhDoanh() : new NhanVienSanXuat();
            nv.Nhap();
            ds.Add(nv);
        }

        Console.WriteLine("\n========== BẢNG LƯƠNG NHÂN VIÊN ==========");
        double tongLuong = 0;
        foreach (var nv in ds)
        {
            nv.Xuat();
            tongLuong += nv.TinhLuong();
        }
        Console.WriteLine($"\n==> TỔNG LƯƠNG CÔNG TY: {tongLuong:N0} VNĐ");
    }
}