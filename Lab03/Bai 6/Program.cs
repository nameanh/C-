using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    // 1. khai bao lop MonHoc
    public class MonHoc
    {
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";
        public byte SoTiet { get; set; }
    }

    // 2. khai bao lop He (Bai 6.1)
    public class He
    {
        public string MaHe { get; set; } = "";
        public string TenHe { get; set; } = "";

        public static List<He> DS_He()
        {
            return new List<He>
            {
                new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
                new He { MaHe = "CD",  TenHe = "Chuyên đề" },
                new He { MaHe = "QT",  TenHe = "Chứng chỉ quốc tế" }
            };
        }
    }

    // 3. khai bao lop DuLieu
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

    // 4. Lop thuc thi Bai 6.2 (Join & Toan tu tap hop)
    public static class Bai6_2
    {
        public static void Run()
        {
            var dsMon = DuLieu.DS_Mon();
            var dsHe = He.DS_He();

            // a. dung join de lke: Ten he, ma mon, ten mon
            var result_a = from h in dsHe
                           join m in dsMon on h.MaHe equals m.He
                           select new { h.TenHe, m.MaMon, m.TenMon };

            Console.WriteLine("\na. Inner Join (Tên hệ, Mã môn, Tên môn):");
            foreach (var item in result_a)
            {
                Console.WriteLine($"  - [{item.TenHe,-20}] {item.MaMon,-8} | {item.TenMon}");
            }

            // b. lke ca nhung he chua co mon hoc (Left Outer Join)
            var result_b = from h in dsHe
                           join m in dsMon on h.MaHe equals m.He into groupMon
                           from m in groupMon.DefaultIfEmpty()
                           select new
                           {
                               TenHe = h.TenHe,
                               MaMon = m != null ? m.MaMon : "(Chưa có)",
                               TenMon = m != null ? m.TenMon : "(Chưa có)"
                           };

            Console.WriteLine("\nb. Left Outer Join (Liệt kê cả hệ chưa có môn học):");
            foreach (var item in result_b)
            {
                Console.WriteLine($"  - [{item.TenHe,-20}] {item.MaMon,-8} | {item.TenMon}");
            }

            // c. lke ca he chua co mon hoc va mon hoc chua khai bao he (Full Outer Join)
            var monChuaHe = dsMon.Where(m => !dsHe.Any(h => h.MaHe == m.He))
                                 .Select(m => new
                                 {
                                     TenHe = "(Chưa khai báo hệ)",
                                     MaMon = m.MaMon,
                                     TenMon = m.TenMon
                                 });

            var result_c = result_b.Concat(monChuaHe);

            Console.WriteLine("\nc. Full Outer Join (Cả hệ chưa có môn và môn chưa có hệ):");
            foreach (var item in result_c)
            {
                Console.WriteLine($"  - [{item.TenHe,-22}] {item.MaMon,-8} | {item.TenMon}");
            }

            // d. chi liet ke he chua co mon va chua khai bao he
            var heChuaMon = from h in dsHe
                            where !dsMon.Any(m => m.He == h.MaHe)
                            select new { TenHe = h.TenHe, MaMon = "(Chưa có)", TenMon = "(Chưa có)" };

            var result_d = heChuaMon.Concat(monChuaHe);

            Console.WriteLine("\nd. Chỉ liệt kê hệ chưa có môn VÀ môn chưa có hệ:");
            foreach (var item in result_d)
            {
                Console.WriteLine($"  - [{item.TenHe,-22}] {item.MaMon,-8} | {item.TenMon}");
            }

            // e. lay 5 mon hoc dau tien co so tiet giam dan; hien thi ten he, ma mon, ten mon, so tiet
            var result_e = (from m in dsMon
                            join h in dsHe on m.He equals h.MaHe into groupHe
                            from h in groupHe.DefaultIfEmpty()
                            orderby m.SoTiet descending
                            select new
                            {
                                TenHe = h != null ? h.TenHe : "(Chưa khai báo)",
                                m.MaMon,
                                m.TenMon,
                                m.SoTiet
                            }).Take(5);

            Console.WriteLine("\ne. Top 5 môn học có số tiết giảm dần:");
            foreach (var item in result_e)
            {
                Console.WriteLine($"  - [{item.TenHe,-20}] {item.MaMon,-8} | {item.TenMon,-42} | Số tiết: {item.SoTiet}");
            }

            // f. cho biet tong so mon hoc cua moi he: Ma he, ten he, tong so mon
            var result_f = from h in dsHe
                           join m in dsMon on h.MaHe equals m.He into groupMon
                           select new
                           {
                               h.MaHe,
                               h.TenHe,
                               TongSoMon = groupMon.Count()
                           };

            Console.WriteLine("\nf. Tổng số môn học của mỗi hệ:");
            foreach (var item in result_f)
            {
                Console.WriteLine($"  - Mã hệ: {item.MaHe,-5} | Tên hệ: {item.TenHe,-20} | Tổng số môn: {item.TongSoMon}");
            }

            // g. Cho biet co bao nhieu loai So tiet khac nhau trong danh sach mon hoc
            int loaiSoTiet = dsMon.Select(m => m.SoTiet).Distinct().Count();
            Console.WriteLine($"\ng. Số loại số tiết khác nhau: {loaiSoTiet}");

            // h. Tim mon hoc dau tien co ten bat dau bang "Lap trinh"
            var result_h = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
            Console.WriteLine("\nh. Môn học đầu tiên bắt đầu bằng 'Lập trình':");
            if (result_h != null)
            {
                Console.WriteLine($"  - Mã môn: {result_h.MaMon} | Tên môn: {result_h.TenMon} | Hệ: {result_h.He} | Số tiết: {result_h.SoTiet}");
            }

            // i. Liet ke cac mon theo tung he, danh so thu tu trong moi nhom
            var result_i = from m in dsMon
                           join h in dsHe on m.He equals h.MaHe into groupHe
                           from h in groupHe.DefaultIfEmpty()
                           group m by new { MaHe = m.He, TenHe = h != null ? h.TenHe : "Chưa khai báo hệ" };

            Console.WriteLine("\ni. Liệt kê các môn theo từng hệ (đánh STT trong nhóm):");
            foreach (var group in result_i)
            {
                Console.WriteLine($"\n  *** Hệ: {group.Key.TenHe} (Mã: {group.Key.MaHe}) ***");
                int stt = 1;
                foreach (var m in group)
                {
                    Console.WriteLine($"    {stt++}. [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiết)");
                }
            }
        }
    }

    // 5. Chuong trinh chinh
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Bai6_2.Run();

            Console.ReadLine();
        }
    }
}