using System;

class Bai8
{
    public static void HoanVi(ref double a, ref double b)
    {
        double temp = a;
        a = b;
        b = temp;
    }

    public static void Run()
    {
        Console.Write("Nhap a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhap b: ");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("Truoc khi hoan vi:");
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);

        HoanVi(ref a, ref b);

        Console.WriteLine("Sau khi hoan vi:");
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
    }
}