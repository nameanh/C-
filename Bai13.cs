using System;

class SinhVien
{
    private string maSinhVien;
    private string hoTen;
    private string diaChi;
    private int namThu;

    public SinhVien()
    {
        maSinhVien = "";
        hoTen = "";
        diaChi = "";
        namThu = 0;
    }

    public void Nhap()
    {
        Console.Write("Nhap ma sinh vien: ");
        maSinhVien = Console.ReadLine();

        Console.Write("Nhap ho ten: ");
        hoTen = Console.ReadLine();

        Console.Write("Nhap dia chi: ");
        diaChi = Console.ReadLine();

        Console.Write("Nhap sinh vien nam thu may: ");
        namThu = int.Parse(Console.ReadLine());
    }

    public void Xuat()
    {
        Console.WriteLine("\n===== THONG TIN SINH VIEN =====");
        Console.WriteLine("Ma sinh vien: " + maSinhVien);
        Console.WriteLine("Ho ten: " + hoTen);
        Console.WriteLine("Dia chi: " + diaChi);
        Console.WriteLine("Nam thu: " + namThu);
    }
}

class Bai13
{
    public static void Run()
    {
        SinhVien sv = new SinhVien();

        sv.Nhap();
        sv.Xuat();
    }
}
