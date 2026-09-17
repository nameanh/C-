using System;

class NhanVien
{
    private string hoTen;
    private double mucLuong;
    private int soNgayVang;

    public NhanVien()
    {
        hoTen = "";
        mucLuong = 0;
        soNgayVang = 0;
    }

    public void Nhap()
    {
        Console.Write("Nhap ho ten: ");
        hoTen = Console.ReadLine();

        Console.Write("Nhap muc luong: ");
        mucLuong = double.Parse(Console.ReadLine());

        Console.Write("Nhap so ngay vang: ");
        soNgayVang = int.Parse(Console.ReadLine());
    }

    public double TinhLuong()
    {
        return mucLuong - soNgayVang * 100000;
    }

    public void Xuat()
    {
        Console.WriteLine("\n===== THONG TIN NHAN VIEN =====");
        Console.WriteLine("Ho ten: " + hoTen);
        Console.WriteLine("Muc luong ban dau: " + mucLuong);
        Console.WriteLine("So ngay vang: " + soNgayVang);
        Console.WriteLine("Luong thuc nhan: " + TinhLuong());
    }
}

class Bai14
{
    public static void Run()
    {
        NhanVien nv = new NhanVien();

        nv.Nhap();
        nv.Xuat();
    }
}