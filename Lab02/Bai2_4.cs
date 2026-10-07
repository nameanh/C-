using System;
using System.Collections.Generic;

public class Mang2D
{
    private int[,] a;

    public Mang2D()
    {
        a = new int[0, 0];
    }

    public Mang2D(int n, int m)
    {
        a = new int[n, m];
    }

    public Mang2D(Mang2D other)
    {
        int n = other.Hang;
        int m = other.Cot;
        a = new int[n, m];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < m; j++)
                a[i, j] = other.a[i, j];
    }

    public int Hang => a.GetLength(0);
    public int Cot => a.GetLength(1);

    public int this[int i, int j]
    {
        get => a[i, j];
        set => a[i, j] = value;
    }

    public void Input()
    {
        Console.Write("n (hàng) = ");
        int n = int.Parse(Console.ReadLine()!);
        Console.Write("m (cột) = ");
        int m = int.Parse(Console.ReadLine()!);
        a = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"a[{i},{j}] = ");
                a[i, j] = int.Parse(Console.ReadLine()!);
            }
        }
    }

    public void Output()
    {
        for (int i = 0; i < Hang; i++)
        {
            for (int j = 0; j < Cot; j++)
                Console.Write(a[i, j] + "\t");
            Console.WriteLine();
        }
    }

    private static bool LaSNT(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++)
            if (n % i == 0) return false;
        return true;
    }

    public int[] SoNguyenTo()
    {
        List<int> ds = new List<int>();
        for (int i = 0; i < Hang; i++)
            for (int j = 0; j < Cot; j++)
                if (LaSNT(a[i, j])) ds.Add(a[i, j]);
        return ds.ToArray();
    }
}

public class Bai2_4
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Mang2D m = new Mang2D();
        m.Input();
        Console.WriteLine("--- Mảng ---");
        m.Output();
        Console.WriteLine("Số nguyên tố: " + string.Join(" ", m.SoNguyenTo()));
    }
}
