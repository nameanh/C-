using System;
using System.Linq;

namespace BaiTapLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Bai 3_1. Thong ke mang SO
            int[] mangSO = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            // a. Cho biet tong so ptu, so ptu chan va so ptu le
            int tongPtu = mangSO.Count();
            int soPtuChan = mangSO.Count(n => n % 2 == 0);
            int soPtuLe = mangSO.Count(n => n % 2 != 0);

            Console.WriteLine("Tong so phan tu la: " + tongPtu);
            Console.WriteLine("So phan tu chan la: " + soPtuChan);
            Console.WriteLine("So phan tu le la: " + soPtuLe);

            // b. Tinh tong cac gtri, gtri lon nhat va gtri nho nhat
            int Sum = mangSO.Sum();
            int Max = mangSO.Max();
            int Min = mangSO.Min();

            Console.WriteLine("\nTong cac gia tri la: " + Sum);
            Console.WriteLine("Gia tri lon nhat la: " + Max);
            Console.WriteLine("Gia tri nho nhat la: " + Min);

            // c. Cho biet co bao nhieu gtri khac nhau trong mang
            int Diff = mangSO.Distinct().Count();
            Console.WriteLine("\nSo gia tri khac nhau la: " + Diff);

            // d. Phan nhom cac ptu theo so du khi chia cho 5
            Console.WriteLine("\nPhan nhom theo so du khi chia 5:");
            var nhomDu = mangSO.GroupBy(n => (n % 5 + 5) % 5);
            for (int i = 0; i < 5; i++)
            {
                var ds = nhomDu.FirstOrDefault(g => g.Key == i);
                string ketQua = ds != null ? string.Join(", ", ds) : "";
                Console.WriteLine($"Cac phan tu chia cho 5 du {i} la: {ketQua}");
            }
        }
    }
}