using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    // 1. Khai bao lop MonHoc
    public class MonHoc
    {
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";
        public byte SoTiet { get; set; }
    }

    // 2. Khai bao lop DuLieu
    public class DuLieu
    {
        public static List<MonHoc> DS_Mon()
        {
            return new List<MonHoc>
            {
                new MonHoc { MaMon = "HP2_1", TenMon = "Nền tảng C#", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP2_2", TenMon = "Công nghệ ADO.NET", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP3_1", TenMon = "Lập trình Windows Forms", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP3_2", TenMon = "Xây dựng ứng dụng Windows Forms", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP4_1", TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP4_2", TenMon = "Xây dựng ứng dụng Web với ASP.NET", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP5_1", TenMon = "Lập trình CSDL SQL Server căn bản", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "HP5_2", TenMon = "Lập trình CSDL SQL Server nâng cao", He = "KTV", SoTiet = 64 },
                new MonHoc { MaMon = "JLCB", TenMon = "Joomla cơ bản", He = "CD", SoTiet = 72 },
                new MonHoc { MaMon = "LINQ", TenMon = "Language-Integrated Query", He = "CD", SoTiet = 64 },
                new MonHoc { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET", He = "CD", SoTiet = 40 },
                new MonHoc { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms", He = "CD", SoTiet = 40 },
                new MonHoc { MaMon = "CC++", TenMon = "Lập trình hướng đối tượng với C/C++", He = "CD", SoTiet = 128 },
                new MonHoc { MaMon = "JQUE", TenMon = "JQuery", He = "CD", SoTiet = 22 },
                new MonHoc { MaMon = "XML", TenMon = "Công nghệ XML", He = "CD", SoTiet = 32 },
                new MonHoc { MaMon = "CRYS", TenMon = "Crystal Report trong Visual Studio", He = "CD", SoTiet = 32 },
                new MonHoc { MaMon = "BWEB", TenMon = "HTML, CSS và JavaScript", He = "CD", SoTiet = 32 },
                new MonHoc { MaMon = "XYZ", TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
            };
        }
    }

    // 3. Chuong trinh chinh - Bai 4_1
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<MonHoc> dsMon = DuLieu.DS_Mon();

            // a. Cho biet tong so mon hien co
            int tongSoMon = dsMon.Count();
            Console.WriteLine($"a. Tong so mon hien co: {tongSoMon}");

            // b. Dem so mon co ten bat dau bang "Lap trinh"
            int countLapTrinh = dsMon.Count(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine($"b. So mon co ten bat dau bang 'Lap trinh': {countLapTrinh}");

            // c. Tinh tong so tiet cua he Ky thuat vien (KTV)
            int tongTietKTV = dsMon.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet);
            Console.WriteLine($"c. Tong so tiet cua he KTV: {tongTietKTV}");

            // d. Cho biet tong so mon cua moi he: He, Tong so mon
            var result_d = dsMon.GroupBy(m => m.He)
                                .Select(g => new { He = g.Key, TongSoMon = g.Count() });

            Console.WriteLine("\nd. Tong so mon cua moi he:");
            foreach (var item in result_d)
            {
                string tenHe = string.IsNullOrEmpty(item.He) ? "Chua xac dinh" : item.He;
                Console.WriteLine($"  - He: {tenHe,-15} | Tong so mon: {item.TongSoMon}");
            }

            // e. Nhom theo So tiet; in So tiet va Tong so mon, sap xep giam dan theo So tiet
            var result_e = dsMon.GroupBy(m => m.SoTiet)
                                .Select(g => new { SoTiet = g.Key, TongSoMon = g.Count() })
                                .OrderByDescending(x => x.SoTiet);

            Console.WriteLine("\ne. Nhom theo So tiet (Giam dan theo So tiet):");
            foreach (var item in result_e)
            {
                Console.WriteLine($"  - So tiet: {item.SoTiet,-3} | Tong so mon: {item.TongSoMon}");
            }

            // f. Cho biet thong tin mon hoc co so tiet cao nhat
            byte maxTiet = dsMon.Max(m => m.SoTiet);
            var result_f = dsMon.Where(m => m.SoTiet == maxTiet);

            Console.WriteLine($"\nf. Thong tin mon hoc co so tiet cao nhat ({maxTiet} tiet):");
            foreach (var m in result_f)
            {
                Console.WriteLine($"  [{m.MaMon}] {m.TenMon} - He: {m.He}");
            }

            // g. Thong ke theo He: tong so mon, tong so tiet, so tiet cao nhat, so tiet thap nhat
            var result_g = dsMon.GroupBy(m => m.He)
                                .Select(g => new
                                {
                                    He = g.Key,
                                    TongSoMon = g.Count(),
                                    TongSoTiet = g.Sum(x => (int)x.SoTiet),
                                    SoTietMax = g.Max(x => x.SoTiet),
                                    SoTietMin = g.Min(x => x.SoTiet)
                                });

            Console.WriteLine("\ng. Thong ke chi tiet theo He:");
            foreach (var item in result_g)
            {
                string tenHe = string.IsNullOrEmpty(item.He) ? "Chua xac dinh" : item.He;
                Console.WriteLine($"  - He: {tenHe,-15} | Tong mon: {item.TongSoMon,-2} | Tong tiet: {item.TongSoTiet,-3} | Tiet Max: {item.SoTietMax,-3} | Tiet Min: {item.SoTietMin}");
            }

            // h. Liet ke cac mon hoc duoc phan nhom theo He
            var result_h = dsMon.GroupBy(m => m.He);

            Console.WriteLine("\nh. Danh sach mon hoc phan nhom theo He:");
            foreach (var g in result_h)
            {
                string tenHe = string.IsNullOrEmpty(g.Key) ? "Chua xac dinh" : g.Key;
                Console.WriteLine($"\n  * HE: {tenHe}");
                foreach (var m in g)
                {
                    Console.WriteLine($"    + [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiet)");
                }
            }

            // i. Liet ke cac mon hoc duoc phan nhom theo So tiet va tang dan theo So tiet
            var result_i = dsMon.GroupBy(m => m.SoTiet)
                                .OrderBy(g => g.Key);

            Console.WriteLine("\ni. Danh sach mon hoc phan nhom theo So tiet (Tang dan):");
            foreach (var g in result_i)
            {
                Console.WriteLine($"\n  * SO TIET: {g.Key}");
                foreach (var m in g)
                {
                    Console.WriteLine($"    + [{m.MaMon}] {m.TenMon} - He: {m.He}");
                }
            }

            // j. Voi he KTV, phan nhom theo hoc phan HP2, HP3, HP4, HP5; sap xep theo Ma mon
            var result_j = dsMon.Where(m => m.He == "KTV" && m.MaMon.Contains("_"))
                                .GroupBy(m => m.MaMon.Split('_')[0])
                                .OrderBy(g => g.Key);

            Console.WriteLine("\nj. He KTV phan nhom theo Hoc phan (HP2, HP3, HP4, HP5):");
            foreach (var g in result_j)
            {
                Console.WriteLine($"\n  * HOC PHAN: {g.Key}");
                foreach (var m in g.OrderBy(x => x.MaMon))
                {
                    Console.WriteLine($"    + [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiet)");
                }
            }

            // k. Phan nhom theo He, chi lay cac mon co So tiet > 40; trong moi nhom sap xep theo Ma mon
            var result_k = dsMon.Where(m => m.SoTiet > 40)
                                .GroupBy(m => m.He);

            Console.WriteLine("\nk. Phan nhom theo He (Chi lay mon So tiet > 40, sap xep theo Ma mon):");
            foreach (var g in result_k)
            {
                string tenHe = string.IsNullOrEmpty(g.Key) ? "Chua xac dinh" : g.Key;
                Console.WriteLine($"\n  * HE: {tenHe}");
                foreach (var m in g.OrderBy(x => x.MaMon))
                {
                    Console.WriteLine($"    + [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiet)");
                }
            }
        }
    }
}