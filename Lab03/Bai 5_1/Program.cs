using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    // 1. Khai bao Class MonHoc
    public class MonHoc
    {
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";
        public byte SoTiet { get; set; }
    }

    // 2. Khai bao Class DuLieu (Dam bao Class nay ton tai)
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

    // 3. Class thuc thi 
    public static class Bai5_1
    {
        public static void Run()
        {
            var dsMon = DuLieu.DS_Mon();

            // a. Liet ke ten cac mon hoc bat dau bang "Lap trinh"
            var result_a = dsMon.Where(m => m.TenMon.StartsWith("Lập trình"))
                                .Select(m => m.TenMon);

            Console.WriteLine("\na. Cac mon hoc bat dau bang 'Lap trinh':");
            foreach (var tenMon in result_a)
            {
                Console.WriteLine($"- {tenMon}");
            }

            // b. Liet ke cac mon thuoc he "CD", sap xep so tiet giam dan roi ma mon tang dan
            var result_b = dsMon.Where(m => m.He == "CD")
                                .OrderByDescending(m => m.SoTiet)
                                .ThenBy(m => m.MaMon);

            Console.WriteLine("\nb. Cac mon thuoc he 'CD' (So tiet giam dan, Ma mon tang dan):");
            foreach (var m in result_b)
            {
                Console.WriteLine($"  [{m.MaMon}] {m.TenMon} - So tiet: {m.SoTiet}");
            }

            // c. Liet ke cac mon co ten chua tu "web", chi lay Ten mon va He
            var result_c = dsMon.Where(m => m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase))
                                .Select(m => new { m.TenMon, m.He });

            Console.WriteLine("\nc. Cac mon co ten chua tu 'web' (Chi lay Ten mon va He):");
            foreach (var item in result_c)
            {
                Console.WriteLine($"  - Ten mon: {item.TenMon} | He: {item.He}");
            }

            // d. Liet ke cac mon thuoc he "KTV", sap xep tang dan theo Ma mon
            var result_d = dsMon.Where(m => m.He == "KTV")
                                .OrderBy(m => m.MaMon);

            Console.WriteLine("\nd. Cac mon thuoc he 'KTV' (Sap xep tang dan theo Ma mon):");
            foreach (var m in result_d)
            {
                Console.WriteLine($"  [{m.MaMon}] {m.TenMon} - He: {m.He}");
            }
        }
    }

    // 4. Program Main
    internal class Program
    {
        static void Main(string[] args)
        {
            Bai5_1.Run();
            Console.ReadLine();
        }
    }
}