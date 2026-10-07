using System;
using System.Collections.Generic;

public class DaySo
{
    private int[] a;

    public DaySo()
    {
        a = Array.Empty<int>();
    }

    public DaySo(int n)
    {
        a = new int[n];
    }

    public DaySo(int[] data)
    {
        a = (int[])data.Clone();
    }

    public DaySo(DaySo other)
    {
        a = (int[])other.a.Clone();
    }

    public int Length => a.Length;

    public int this[int i]
    {
        get => a[i];
        set => a[i] = value;
    }

    public void Input()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine()!);
        a = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"a[{i}] = ");
            a[i] = int.Parse(Console.ReadLine()!);
        }
    }

    public void Output()
    {
        Console.WriteLine("Dãy: " + string.Join(" ", a));
    }

    public int[] SoChan()
    {
        List<int> ds = new List<int>();
        foreach (int x in a)
        {
            if (x % 2 == 0) ds.Add(x);
        }
        return ds.ToArray();
    }
}

public class Bai2_3
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        DaySo d = new DaySo();
        d.Input();
        d.Output();
        if (d.Length > 0)
            Console.WriteLine($"Indexer [0] = {d[0]}");
        Console.WriteLine("Số chẵn: " + string.Join(" ", d.SoChan()));
    }
}
