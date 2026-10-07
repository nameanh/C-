using System;
using System.Collections.Generic;

public class ThiSinh
{
    public string SBD { get; set; } = "";
    public string HoTen { get; set; } = "";
    public double Bai1 { get; set; }
    public double Bai2 { get; set; }
    public double Bai3 { get; set; }

    public virtual void Nhap()
    {
        Console.Write("SBD: "); SBD = Console.ReadLine() ?? "";
        Console.Write("Họ tên: "); HoTen = Console.ReadLine() ?? "";
        Console.Write("Điểm Bài 1: "); Bai1 = double.Parse(Console.ReadLine()!);
        Console.Write("Điểm Bài 2: "); Bai2 = double.Parse(Console.ReadLine()!);
        Console.Write("Điểm Bài 3: "); Bai3 = double.Parse(Console.ReadLine()!);
    }

    public virtual double TinhTongDiem() => Bai1 + Bai2 + Bai3;

    public virtual void Xuat()
    {
        Console.WriteLine($"SBD: {SBD} | Họ tên: {HoTen} | Tổng điểm: {TinhTongDiem()}");
    }
}

// Thí sinh Chuyên
public class ThiSinhChuyen : ThiSinh
{
    public double TiengAnh { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Điểm Tiếng Anh: "); TiengAnh = double.Parse(Console.ReadLine()!);
    }

    public override double TinhTongDiem()
    {
        double tong = base.TinhTongDiem();
        if (TiengAnh >= 7 && TiengAnh <= 8) tong += 1;
        else if (TiengAnh >= 9 && TiengAnh <= 10) tong += 2;
        return tong;
    }
}

// Thí sinh Siêu cúp
public class ThiSinhSieuCup : ThiSinh
{
    public double CSDL { get; set; }

    public override void Nhap()
    {
        base.Nhap();
        Console.Write("Điểm CSDL: "); CSDL = double.Parse(Console.ReadLine()!);
    }

    public override double TinhTongDiem() => base.TinhTongDiem() + CSDL;
}

public class Bai3_6
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<ThiSinh> ds = new List<ThiSinh>();

        Console.Write("Nhập số lượng thí sinh: ");
        int n = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\n--- Thí sinh {i + 1} (1: Chuyên, 2: Siêu Cúp) ---");
            int loai = int.Parse(Console.ReadLine()!);
            ThiSinh ts = loai == 1 ? new ThiSinhChuyen() : new ThiSinhSieuCup();
            ts.Nhap();
            ds.Add(ts);
        }

        Console.WriteLine("\n========== KẾT QUẢ CUỘC THI ==========");
        foreach (var ts in ds)
        {
            ts.Xuat();
        }
    }
}