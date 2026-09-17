// Chương trình chính

using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("===== BAI TAP C# =====");
            Console.WriteLine("Bai1");
            Console.WriteLine("Bai2");
            Console.WriteLine("Bai3");
            Console.WriteLine("Bai4");
            Console.WriteLine("Bai5");
            Console.WriteLine("Bai6");
            Console.WriteLine("Bai7");
            Console.WriteLine("Bai8");
            Console.WriteLine("Bai9");
            Console.WriteLine("Bai10");
            Console.WriteLine("Bai11");
            Console.WriteLine("Bai12");
            Console.WriteLine("Bai13");
            Console.WriteLine("Bai14");
            Console.WriteLine("Bai15");
            Console.WriteLine("Bai16");
            Console.WriteLine("Bai17");
            Console.WriteLine("0. Thoat");

            Console.Write("\nNhap so bai muon chay: ");

            if (!int.TryParse(Console.ReadLine(), out int bai))
            {
                Console.WriteLine("Vui long nhap so!");
                Console.ReadKey();
                continue;
            }

            if (bai == 0)
            {
                Console.WriteLine("Da thoat chuong trinh.");
                break;
            }

            if (bai < 1 || bai > 17)
            {
                Console.WriteLine("Bai khong ton tai!");
                Console.ReadKey();
                continue;
            }

            string tenClass = "Bai" + bai;
            Type? loaiBai = Type.GetType(tenClass);

            if (loaiBai == null)
            {
                Console.WriteLine("\nBai nay chua duoc lam!");
                Console.ReadKey();
                continue;
            }

            MethodInfo? phuongThuc = loaiBai.GetMethod("Run");

            if (phuongThuc == null)
            {
                Console.WriteLine("\nBai nay chua co phuong thuc Run()!");
                Console.ReadKey();
                continue;
            }

            Console.Clear();

            phuongThuc.Invoke(null, null);

            Console.WriteLine("\nNhan phim bat ky de quay lai menu...");
            Console.ReadKey();
        }
    }
}