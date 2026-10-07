using System;
using System.Collections;

public class ArrayPoint
{
    private ArrayList points;

    public ArrayPoint()
    {
        points = new ArrayList();
    }

    public ArrayPoint(ArrayPoint other)
    {
        points = new ArrayList();
        foreach (Point p in other.points)
            points.Add(new Point(p));
    }

    public int Count => points.Count;

    public Point this[int i]
    {
        get => (Point)points[i]!;
        set => points[i] = value;
    }

    public void Add(Point p) => points.Add(p);

    public void Input()
    {
        Console.Write("Số điểm n: ");
        int n = int.Parse(Console.ReadLine()!);
        points.Clear();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Điểm [{i}]:");
            Point p = new Point();
            p.Input();
            points.Add(p);
        }
    }

    public void Output()
    {
        for (int i = 0; i < points.Count; i++)
            Console.WriteLine($"[{i}] {this[i]}");
    }
}

public class Bai2_1
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ArrayPoint ds = new ArrayPoint();
        ds.Input();
        Console.WriteLine("--- Danh sách điểm ---");
        ds.Output();
        if (ds.Count > 0)
            Console.WriteLine($"Indexer [0] = {ds[0]}");
    }
}
