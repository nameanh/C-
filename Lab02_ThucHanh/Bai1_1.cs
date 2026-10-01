using System;

public class SinhVien
{
    private string hoTen = "";
    private int namSinh;

    public string HoTen { get => hoTen; set => hoTen = value; }
    public int NamSinh { get => namSinh; set => namSinh = value; }

    public SinhVien()
    {
        hoTen = "";
        namSinh = 2000;
    }

    public SinhVien(string hoTen, int namSinh)
    {
        this.hoTen = hoTen;
        this.namSinh = namSinh;
    }

    public void Input()
    {
        Console.Write("Họ tên: ");
        hoTen = Console.ReadLine() ?? "";
        Console.Write("Năm sinh: ");
        namSinh = int.Parse(Console.ReadLine()!);
    }

    public int TinhTuoi() => DateTime.Now.Year - namSinh;

    public void Output()
    {
        Console.WriteLine($"Sinh viên: {hoTen} | Năm sinh: {namSinh} | Tuổi: {TinhTuoi()}");
    }
}

public class Bai1_1
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        SinhVien sv = new SinhVien();
        sv.Input();
        sv.Output();
    }
}
