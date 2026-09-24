// Bài 3: Nhập số nguyên

using System;

class Bai3
{
    public static void Run()
    {
        // Nhập x
        Console.Write("Nhap so nguyen x: ");
        int x = int.Parse(Console.ReadLine() ?? "0");

        // Nhập y
        Console.Write("Nhap so nguyen y: ");
        int y = int.Parse(Console.ReadLine() ?? "0");

        // Tính x^y
        double ketQua = Math.Pow(x, y);

        // Xuất kết quả
        Console.WriteLine("Ket qua " + x + " mu " + y + " la: " + ketQua);
    }
}