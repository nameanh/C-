using System;
using System.Collections.Generic;

public class PersonList
{
    private List<Person> ds;

    public PersonList()
    {
        ds = new List<Person>();
    }

    public PersonList(PersonList other)
    {
        ds = new List<Person>();
        foreach (Person p in other.ds)
            ds.Add(new Person(p));
    }

    public void Add(Person x) => ds.Add(x);

    public void Input()
    {
        Console.Write("Số người n: ");
        int n = int.Parse(Console.ReadLine()!);
        ds.Clear();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Người [{i}]:");
            Person p = new Person();
            p.Input();
            ds.Add(p);
        }
    }

    public void Output()
    {
        if (ds.Count == 0)
        {
            Console.WriteLine("(rỗng)");
            return;
        }
        for (int i = 0; i < ds.Count; i++)
        {
            Console.Write($"[{i}] ");
            ds[i].Output();
        }
    }

    public PersonList LivingPeople()
    {
        PersonList living = new PersonList();
        foreach (Person p in ds)
        {
            if (p.IsLiving())
                living.Add(new Person(p));
        }
        return living;
    }
}

public class Bai2_2
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        PersonList ds = new PersonList();
        ds.Input();
        Console.WriteLine("--- Tất cả ---");
        ds.Output();
        Console.WriteLine("--- Còn sống ---");
        ds.LivingPeople().Output();
    }
}
