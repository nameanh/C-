using System;

public class Person : IComparable<Person>
{
    private string id = "";
    private string name = "";
    private int yob;
    private int yod;

    public string Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public int Yob { get => yob; set => yob = value; }
    public int Yod { get => yod; set => yod = value; }

    public Person()
    {
        id = "";
        name = "";
        yob = 0;
        yod = 0;
    }

    public Person(Person p)
    {
        id = p.id;
        name = p.name;
        yob = p.yob;
        yod = p.yod;
    }

    public void Input()
    {
        Console.Write("ID: ");
        id = Console.ReadLine() ?? "";
        Console.Write("Họ tên: ");
        name = Console.ReadLine() ?? "";
        Console.Write("Năm sinh: ");
        yob = int.Parse(Console.ReadLine()!);
        Console.Write("Năm mất (0 nếu còn sống): ");
        yod = int.Parse(Console.ReadLine()!);
    }

    public void Output()
    {
        string tt = IsLiving() ? "Còn sống" : $"Mất năm {yod}";
        Console.WriteLine($"ID: {id} | Tên: {name} | NS: {yob} | {tt}");
    }

    public bool IsLiving() => yod == 0;

    public int CompareTo(Person? other)
    {
        if (other is null) return 1;
        return string.Compare(name, other.name, StringComparison.CurrentCulture);
    }
}
