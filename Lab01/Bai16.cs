using System;

class Bai16
{
    public static void Run()
    {
        Console.Write("Nhap so luong nguoi n: ");
        int n = int.Parse(Console.ReadLine());

        string[] hoTen = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhap ho ten nguoi thu " + (i + 1) + ": ");
            hoTen[i] = Console.ReadLine();
        }

        Array.Sort(hoTen);

        Console.WriteLine("\nDanh sach sau khi sap xep:");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(hoTen[i]);
        }
    }
}