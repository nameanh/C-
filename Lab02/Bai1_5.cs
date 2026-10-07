using System;

public class Bai1_5
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        DonThuc p = new DonThuc();
        Console.WriteLine("Nhập đơn thức P(x) = a * x^n");
        p.Input();
        Console.Write("Nhập x: ");
        double x = double.Parse(Console.ReadLine()!);
        Console.WriteLine($"P(x) = {p}");
        Console.WriteLine($"P({x}) = {p.GiaTri(x)}");
        DonThuc q = p.DaoHam();
        Console.WriteLine($"P'(x) = {q}");
        Console.WriteLine($"P'({x}) = {q.GiaTri(x)}");
    }
}
