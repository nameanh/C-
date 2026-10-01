using System;
using System.Collections.Generic;

public class DayPhanSo
{
    private List<PhanSo> ds = new List<PhanSo>();

    public void Nhap()
    {
        Console.Write("Nhập số lượng phân số n: ");
        int n = int.Parse(Console.ReadLine()!);
        ds.Clear();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"--- Phân số [{i + 1}] ---");
            PhanSo p = new PhanSo();
            p.Input();
            ds.Add(p);
        }
    }

    public void Xuat()
    {
        Console.WriteLine("Dãy phân số: " + string.Join(", ", ds));
    }

    // Tính tổng của n phân số trong dãy
    public PhanSo TinhTong()
    {
        PhanSo tong = new PhanSo(0, 1);
        foreach (var p in ds)
        {
            tong += p;
        }
        return tong;
    }
}

public class Bai2_4_DayPhanSo
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        DayPhanSo dps = new DayPhanSo();
        dps.Nhap();
        dps.Xuat();
        Console.WriteLine($"\nTổng của dãy phân số = {dps.TinhTong()}");
    }
}