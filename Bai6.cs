using System;

class Bai6
{
    public static int TimMax(int a, int b, int c)
    {
        int max = a;

        if (b > max)
            max = b;

        if (c > max)
            max = c;

        return max;
    }

    public static void Run()
    {
        Console.Write("Nhap a: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Nhap b: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Nhap c: ");
        int c = int.Parse(Console.ReadLine());

        int max = TimMax(a, b, c);

        Console.WriteLine("So lon nhat la: " + max);
    }
}