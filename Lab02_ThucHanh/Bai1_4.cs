using System;

public class Bai1_4
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Nhập phân số A:");
        PhanSo a = new PhanSo();
        a.Input();
        Console.WriteLine("Nhập phân số B:");
        PhanSo b = new PhanSo();
        b.Input();

        Console.WriteLine($"A = {a}");
        Console.WriteLine($"B = {b}");
        Console.WriteLine($"+A = {+a}");
        Console.WriteLine($"-A = {-a}");
        Console.WriteLine($"A + B = {a + b}");
        Console.WriteLine($"A - B = {a - b}");
        Console.WriteLine($"A * B = {a * b}");
        Console.WriteLine($"A / B = {a / b}");
        Console.WriteLine($"A > B : {a > b}");
        Console.WriteLine($"A < B : {a < b}");
        Console.WriteLine($"A >= B : {a >= b}");
        Console.WriteLine($"A <= B : {a <= b}");
        Console.WriteLine($"A == B : {a == b}");
        Console.WriteLine($"A != B : {a != b}");
    }
}
