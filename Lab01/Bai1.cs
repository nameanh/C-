// Bài 1: Mã nguồn chương trình

using System;

class Bai1
{
    public static void Run()
    {
        // Nhập họ tên
        Console.Write("Nhap ho ten: ");
        string hoTen = Console.ReadLine() ?? "";

        // Xuất họ tên
        Console.WriteLine("Ho ten vua nhap: " + hoTen);
    }
}