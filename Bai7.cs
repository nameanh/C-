using System;

class Bai7
{
    public static bool LaSoNguyenTo(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    public static void Run()
    {
        Console.Write("Nhap n: ");
        int n = int.Parse(Console.ReadLine());

        if (LaSoNguyenTo(n))
            Console.WriteLine(n + " la so nguyen to.");
        else
            Console.WriteLine(n + " khong phai la so nguyen to.");
    }
}