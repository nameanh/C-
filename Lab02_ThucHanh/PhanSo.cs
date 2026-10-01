using System;

public class PhanSo : IComparable<PhanSo>
{
    private int tu;
    private int mau;

    public int Tu { get => tu; set { tu = value; RutGon(); } }
    public int Mau { get => mau; set { mau = value == 0 ? 1 : value; RutGon(); } }

    public PhanSo()
    {
        tu = 0;
        mau = 1;
    }

    public PhanSo(int tu, int mau)
    {
        this.tu = tu;
        this.mau = mau == 0 ? 1 : mau;
        RutGon();
    }

    public PhanSo(int tu) : this(tu, 1) { }

    public PhanSo(PhanSo p)
    {
        tu = p.tu;
        mau = p.mau;
    }

    private static int UCLN(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        while (b != 0)
        {
            int r = a % b;
            a = b;
            b = r;
        }
        return a == 0 ? 1 : a;
    }

    private void RutGon()
    {
        if (mau == 0) mau = 1;
        if (mau < 0)
        {
            tu = -tu;
            mau = -mau;
        }
        int d = UCLN(tu, mau);
        tu /= d;
        mau /= d;
    }

    public void Input()
    {
        Console.Write("Tử: ");
        tu = int.Parse(Console.ReadLine()!);
        Console.Write("Mẫu: ");
        mau = int.Parse(Console.ReadLine()!);
        if (mau == 0) mau = 1;
        RutGon();
    }

    public override string ToString() => mau == 1 ? tu.ToString() : $"{tu}/{mau}";

    public static PhanSo operator +(PhanSo p) => new PhanSo(p);
    public static PhanSo operator -(PhanSo p) => new PhanSo(-p.tu, p.mau);

    public static PhanSo operator +(PhanSo a, PhanSo b) => new PhanSo(a.tu * b.mau + b.tu * a.mau, a.mau * b.mau);
    public static PhanSo operator -(PhanSo a, PhanSo b) => a + (-b);
    public static PhanSo operator *(PhanSo a, PhanSo b) => new PhanSo(a.tu * b.tu, a.mau * b.mau);
    public static PhanSo operator /(PhanSo a, PhanSo b) => new PhanSo(a.tu * b.mau, a.mau * b.tu);

    public int CompareTo(PhanSo? other)
    {
        if (other is null) return 1;
        return (tu * other.mau).CompareTo(other.tu * mau);
    }

    public static bool operator >(PhanSo a, PhanSo b) => a.CompareTo(b) > 0;
    public static bool operator <(PhanSo a, PhanSo b) => a.CompareTo(b) < 0;
    public static bool operator >=(PhanSo a, PhanSo b) => a.CompareTo(b) >= 0;
    public static bool operator <=(PhanSo a, PhanSo b) => a.CompareTo(b) <= 0;
    public static bool operator ==(PhanSo a, PhanSo b) => a.CompareTo(b) == 0;
    public static bool operator !=(PhanSo a, PhanSo b) => a.CompareTo(b) != 0;

    public override bool Equals(object? obj) => obj is PhanSo p && this == p;
    public override int GetHashCode() => HashCode.Combine(tu, mau);
}
