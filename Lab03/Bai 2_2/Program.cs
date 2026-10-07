using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Bai 2_2. Truy van mang CHUOI
        string[] mangChuoi = {
            "đầu", "lòng", "hai", "ả", "tố", "nga",
            "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân"
        };

        // a. Liet ke cac ptu co 4 ki tu va sap xep tang dan theo ki tu dau tien
        var result2_2_a = mangChuoi
            .Where(s => s.Length == 4)
            .OrderBy(s => s[0]);

        Console.Write("\nCac phan tu co 4 ki tu duoc xep tang dan la: ");
        foreach (var item in result2_2_a)
        {
            Console.Write(item + " ");
        }

        // b. Bien doi moi ptu thanh dang <chu thuong> - <CHU HOA>
        var result2_2_b = mangChuoi.Select(s => $"{s.ToLower()} - {s.ToUpper()}");

        Console.WriteLine("\n\nCac ki tu duoc bien doi theo dang chu thuong / chu hoa la: ");
        foreach (var item in result2_2_b)
        {
            Console.Write(item + ", ");
        }

        // c. Liet ke cac ptu co ki tu "u"
        var result2_2_c = mangChuoi.Where(s => s.Contains("u"));

        Console.Write("\n\nCac phan tu co chua ki tu u la: ");
        foreach (var item in result2_2_c)
        {
            Console.Write(item + ", ");
        }

        // d. Liet ke cac tu bat dau bang chu in hoa
        var result2_2_d = mangChuoi.Where(s => char.IsUpper(s[0]));

        Console.Write("\n\nCac tu bat dau bang chu in hoa la: ");
        foreach (var item in result2_2_d)
        {
            Console.Write(item + ", ");
        }
    }
}