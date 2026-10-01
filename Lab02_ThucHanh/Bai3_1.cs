using System;

public class Bai3_1
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Dùng lớp Person đã cài đặt IComparable<Person> ở Person.cs
        Person[] ds = new Person[]
        {
            new Person { Id = "01", Name = "Cường", Yob = 2002 },
            new Person { Id = "02", Name = "An", Yob = 2001 },
            new Person { Id = "03", Name = "Bình", Yob = 2003 }
        };

        Console.WriteLine("--- Danh sách ban đầu ---");
        foreach (var p in ds) p.Output();

        // Sử dụng phương thức tĩnh Array.Sort
        Array.Sort(ds);

        Console.WriteLine("\n--- Danh sách sau khi Array.Sort() theo Tên ---");
        foreach (var p in ds) p.Output();
    }
}