using System;

public class Point : IComparable<Point>
{
    private double x;
    private double y;

    public double X { get => x; set => x = value; }
    public double Y { get => y; set => y = value; }

    public Point()
    {
        x = 0;
        y = 0;
    }

    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public Point(Point p)
    {
        x = p.x;
        y = p.y;
    }

    public void Input()
    {
        Console.Write("x = ");
        x = double.Parse(Console.ReadLine()!);
        Console.Write("y = ");
        y = double.Parse(Console.ReadLine()!);
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString() => $"({x}, {y})";

    public static Point operator +(Point a, Point b) => new Point(a.x + b.x, a.y + b.y);
    public static Point operator -(Point a, Point b) => new Point(a.x - b.x, a.y - b.y);
    public static Point operator -(Point a) => new Point(-a.x, -a.y);

    public double Distance(Point other)
    {
        double dx = x - other.x;
        double dy = y - other.y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public static double Distance(Point a, Point b) => a.Distance(b);

    public Point Midpoint(Point other) => new Point((x + other.x) / 2, (y + other.y) / 2);

    public static Point Midpoint(Point a, Point b) => a.Midpoint(b);

    public int CompareTo(Point? other)
    {
        if (other is null) return 1;
        int c = x.CompareTo(other.x);
        return c != 0 ? c : y.CompareTo(other.y);
    }
}
