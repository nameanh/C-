// Bài 4: Kiểm tra số nguyên

using System;

class Bai4
{
    public static void Run()
    {
        // Nhập x
        Console.Write("Nhap so nguyen x: ");
        if (!int.TryParse(Console.ReadLine(), out int x))
        {
            Console.WriteLine("Loi: x khong phai la so nguyen!");
            return;
        }

        // Nhập y
        Console.Write("Nhap so nguyen y: ");
        if (!int.TryParse(Console.ReadLine(), out int y))
        {
            Console.WriteLine("Loi: y khong phai la so nguyen!");
            return;
        }

        // Tính x^y
        double ketQua = Math.Pow(x, y);

        // Xuất kết quả
        Console.WriteLine("Ket qua " + x + " mu " + y + " la: " + ketQua);
    }
}