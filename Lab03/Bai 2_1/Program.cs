using System;
using System.Linq;

namespace BaiTapLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Khoi tao mang so nguyen
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            // a. Liet ke phan tu chia het cho cả 4 va 3
            var result2_1_a = mangSo.Where(n => n % 4 == 0 && n % 3 == 0);
            Console.Write("a. Cac phan tu chia het cho 4 va 3 la: ");
            foreach (var item in result2_1_a)
            {
                Console.Write(item + " ");
            }

            // b. Liet ke cac phan tu nho hon hoac bang 3
            var result2_1_b = mangSo.Where(n => n <= 3);
            Console.Write("\n\nb. Cac phan tu nho hon hoac bang 3 la: ");
            foreach (var item in result2_1_b)
            {
                Console.Write(item + " ");
            }

            // c. Tao day moi: so chan chia doi, so le giu nguyen
            var result2_1_c = mangSo.Select(n => n % 2 == 0 ? n / 2 : n);
            Console.Write("\n\nc. Day so moi (so chan chia 2, so le giu nguyen) la: ");
            foreach (var item in result2_1_c)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine(); // Xuong dong khi ket thuc
        }
    }
}