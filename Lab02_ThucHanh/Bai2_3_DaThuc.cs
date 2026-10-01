using System;
using System.Collections.Generic;

public class DaThuc
{
    private DonThuc[] dt;

    public DaThuc()
    {
        dt = Array.Empty<DonThuc>();
    }

    public DaThuc(int bac)
    {
        dt = new DonThuc[bac + 1];
        for (int i = 0; i <= bac; i++)
            dt[i] = new DonThuc(0, i);
    }

    public DaThuc(DaThuc other)
    {
        dt = new DonThuc[other.dt.Length];
        for (int i = 0; i < dt.Length; i++)
            dt[i] = new DonThuc(other.dt[i]);
    }

    public int Bac => dt.Length == 0 ? -1 : dt.Length - 1;

    public DonThuc this[int i]
    {
        get => dt[i];
        set => dt[i] = value;
    }

    public void Input()
    {
        Console.Write("Bậc n = ");
        int n = int.Parse(Console.ReadLine()!);
        dt = new DonThuc[n + 1];
        for (int i = 0; i <= n; i++)
        {
            Console.Write($"Hệ số a{i}: ");
            double heSo = double.Parse(Console.ReadLine()!);
            dt[i] = new DonThuc(heSo, i);
        }
    }

    public void Output()
    {
        Console.WriteLine("P(x) = " + ToString());
    }

    public double GiaTri(double x)
    {
        double s = 0;
        foreach (DonThuc d in dt)
            s += d.GiaTri(x);
        return s;
    }

    public override string ToString()
    {
        if (dt.Length == 0) return "0";
        List<string> parts = new List<string>();
        for (int i = 0; i < dt.Length; i++)
        {
            if (dt[i].A == 0) continue;
            parts.Add(dt[i].ToString());
        }
        return parts.Count == 0 ? "0" : string.Join(" + ", parts);
    }
}

public class Bai2_3_DaThuc
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        DaThuc p = new DaThuc();
        p.Input();
        p.Output();
        Console.Write("Nhập x: ");
        double x = double.Parse(Console.ReadLine()!);
        Console.WriteLine($"P({x}) = {p.GiaTri(x)}");
    }
}
