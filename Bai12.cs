using System;

class Bai12
{
    public static void Run()
    {
        Console.Write("Nhap chuoi: ");
        string chuoi = Console.ReadLine();

        Console.WriteLine("Chuoi thuong: " + chuoi.ToLower());
        Console.WriteLine("Chuoi hoa: " + chuoi.ToUpper());

        string[] tu = chuoi.Split(
            new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries
        );

        Console.WriteLine("So tu trong chuoi: " + tu.Length);
    }
}