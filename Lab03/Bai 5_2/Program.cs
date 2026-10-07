using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    public class MonHoc
    {
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";
        public byte SoTiet { get; set; }
    }

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

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var dsMon = DuLieu.DS_Mon();

            // a. Tong so mon hien co
            Console.WriteLine($"a. Tong so mon hien co: {dsMon.Count()}");

            // b. Dem so mon co ten bat dau bang "Lap trinh"
            Console.WriteLine($"b. So mon bat dau bang 'Lap trinh': {dsMon.Count(m => m.TenMon.StartsWith("Lập trình"))}");

            // c. Tinh tong so tiet cua he KTV
            Console.WriteLine($"c. Tong so tiet cua he KTV: {dsMon.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet)}");

            // d. Tong so mon cua moi he
            var result_d = dsMon.GroupBy(m => m.He).Select(g => new { He = g.Key, TongSoMon = g.Count() });
            Console.WriteLine("\nd. Tong so mon cua moi he:");
            foreach (var item in result_d)
            {
                string tenHe = string.IsNullOrEmpty(item.He) ? "Chua xac dinh" : item.He;
                Console.WriteLine($"  - He: {tenHe,-15} | Tong so mon: {item.TongSoMon}");
            }

            // e. Nhom theo So tiet, giam dan theo So tiet
            var result_e = dsMon.GroupBy(m => m.SoTiet)
                                .Select(g => new { SoTiet = g.Key, TongSoMon = g.Count() })
                                .OrderByDescending(x => x.SoTiet);
            Console.WriteLine("\ne. Nhom theo So tiet (Giam dan theo So tiet):");
            foreach (var item in result_e)
            {
                Console.WriteLine($"  - So tiet: {item.SoTiet,-3} | Tong so mon: {item.TongSoMon}");
            }

            // f. Mon hoc co so tiet cao nhat
            byte maxTiet = dsMon.Max(m => m.SoTiet);
            Console.WriteLine($"\nf. Mon hoc co so tiet cao nhat ({maxTiet} tiet):");
            foreach (var m in dsMon.Where(m => m.SoTiet == maxTiet))
            {
                Console.WriteLine($"  [{m.MaMon}] {m.TenMon} - He: {m.He}");
            }

            // g. Thong ke chi tiet theo He
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

            // h. Phan nhom theo He
            Console.WriteLine("\nh. Danh sach mon hoc phan nhom theo He:");
            foreach (var g in dsMon.GroupBy(m => m.He))
            {
                string tenHe = string.IsNullOrEmpty(g.Key) ? "Chua xac dinh" : g.Key;
                Console.WriteLine($"\n  * HE: {tenHe}");
                foreach (var m in g)
                {
                    Console.WriteLine($"    + [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiet)");
                }
            }

            // i. Phan nhom theo So tiet (Tang dan)
            Console.WriteLine("\ni. Danh sach mon hoc phan nhom theo So tiet (Tang dan):");
            foreach (var g in dsMon.GroupBy(m => m.SoTiet).OrderBy(g => g.Key))
            {
                Console.WriteLine($"\n  * SO TIET: {g.Key}");
                foreach (var m in g)
                {
                    Console.WriteLine($"    + [{m.MaMon}] {m.TenMon} - He: {m.He}");
                }
            }

            // j. He KTV phan nhom theo Hoc phan HP2, HP3, HP4, HP5
            Console.WriteLine("\nj. He KTV phan nhom theo Hoc phan:");
            var result_j = dsMon.Where(m => m.He == "KTV" && m.MaMon.Contains("_"))
                                .GroupBy(m => m.MaMon.Split('_')[0])
                                .OrderBy(g => g.Key);
            foreach (var g in result_j)
            {
                Console.WriteLine($"\n  * HOC PHAN: {g.Key}");
                foreach (var m in g.OrderBy(x => x.MaMon))
                {
                    Console.WriteLine($"    + [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiet)");
                }
            }

            // k. Phan nhom theo He, So tiet > 40
            Console.WriteLine("\nk. Phan nhom theo He (So tiet > 40):");
            foreach (var g in dsMon.Where(m => m.SoTiet > 40).GroupBy(m => m.He))
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