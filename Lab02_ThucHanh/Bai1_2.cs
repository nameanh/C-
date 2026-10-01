using System;

public class Bai1_2
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Nhập điểm A:");
        Point a = new Point();
        a.Input();
        Console.WriteLine("Nhập điểm B:");
        Point b = new Point();
        b.Input();

        Console.WriteLine($"A = {a}");
        Console.WriteLine($"B = {b}");
        Console.WriteLine($"A + B = {a + b}");
        Console.WriteLine($"A - B = {a - b}");
        Console.WriteLine($"-A = {-a}");

        Console.WriteLine($"Khoảng cách (thành viên): {a.Distance(b)}");
        Console.WriteLine($"Khoảng cách (tĩnh): {Point.Distance(a, b)}");
        Console.WriteLine($"Trung điểm (thành viên): {a.Midpoint(b)}");
        Console.WriteLine($"Trung điểm (tĩnh): {Point.Midpoint(a, b)}");
    }
}
