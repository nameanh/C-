using System;
using System.Linq;

namespace BaiThucHanhLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Bai 3.2. Thong ke mang CHUOI
            string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì", "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
 "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

            // a. Tim cac phan tu co chieu dai ngan nhat va dai nhat
            int minLen = monAn.Min(s => s.Length);
            int maxLen = monAn.Max(s => s.Length);
            var result3_2_a_min = monAn.Where(s => s.Length == minLen);
            var result3_2_a_max = monAn.Where(s => s.Length == maxLen);

            Console.Write("Cac phan tu co chieu dai ngan nhat la: ");
            Console.WriteLine(string.Join(", ", result3_2_a_min));

            Console.Write("Cac phan tu co chieu dai dai nhat la: ");
            Console.WriteLine(string.Join(", ", result3_2_a_max));

            // b. Phan nhom theo tu dau tien cua ten mon va liet ke cac phan tu trong tung nhom
            var result3_2_b = monAn.GroupBy(s => s.Split(' ')[0]);

            Console.WriteLine("\nPhan nhom theo tu dau tien:");
            foreach (var group in result3_2_b)
            {
                Console.WriteLine($"- Nhom '{group.Key}': {string.Join(", ", group)}");
            }

            // c. Dem so phan tu co tu dau tien la "Banh"
            int countBanh = monAn.Count(s => s.StartsWith("Bánh"));
            Console.WriteLine("\nSo phan tu co tu dau tien la 'Banh' la: " + countBanh);
        }
    }
}