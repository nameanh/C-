// Bài 2: Xuất và nhập chuỗi

using System;

class Bai2
{
    public static void Run()
    {
        // Nhập họ tên
        Console.Write("Nhap ho ten cua ban: ");
        string hoTen = Console.ReadLine() ?? "";

        // Xuất lời chào
        Console.WriteLine("Chao ban " + hoTen + "!");
    }
}