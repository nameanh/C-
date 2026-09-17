using System;

class Bai11
{
    public string DaoChuoi(string chuoi)
    {
        char[] mang = chuoi.ToCharArray();

        Array.Reverse(mang);

        return new string(mang);
    }

    public static void Run()
    {
        Bai11 bai = new Bai11();

        Console.Write("Nhap chuoi: ");
        string chuoi = Console.ReadLine();

        string ketQua = bai.DaoChuoi(chuoi);

        Console.WriteLine("Chuoi sau khi dao: " + ketQua);
    }
}