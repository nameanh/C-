using System;

public class Bai1_3
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Person p = new Person();
        p.Input();
        Console.WriteLine("--- Thông tin ---");
        p.Output();
        Console.WriteLine($"Còn sống? {p.IsLiving()}");

        Person copy = new Person(p);
        Console.WriteLine("--- Bản sao ---");
        copy.Output();
    }
}
