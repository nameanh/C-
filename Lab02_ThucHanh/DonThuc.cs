using System;

public class DonThuc
{
    private double a;
    private int n;

    public double A { get => a; set => a = value; }
    public int N { get => n; set => n = value < 0 ? 0 : value; }

    public DonThuc()
    {
        a = 0;
        n = 0;
    }

    public DonThuc(double a, int n)
    {
        this.a = a;
        this.n = n < 0 ? 0 : n;
    }

    public DonThuc(DonThuc d)
    {
        a = d.a;
        n = d.n;
    }

    public void Input()
    {
        Console.Write("Hệ số a: ");
        a = double.Parse(Console.ReadLine()!);
        Console.Write("Số mũ n: ");
        n = int.Parse(Console.ReadLine()!);
        if (n < 0) n = 0;
    }

    public double GiaTri(double x) => a * Math.Pow(x, n);

    public DonThuc DaoHam()
    {
        if (n == 0) return new DonThuc(0, 0);
        return new DonThuc(a * n, n - 1);
    }

    public override string ToString()
    {
        if (n == 0) return a.ToString();
        if (n == 1) return $"{a}x";
        return $"{a}x^{n}";
    }
}
