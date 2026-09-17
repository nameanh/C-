using System;
using System.Collections.Generic;

class Bai15
{
    private int[] a;

    public void NhapMang()
    {
        Console.Write("Nhap so phan tu n: ");
        int n = int.Parse(Console.ReadLine());

        a = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("a[" + i + "] = ");
            a[i] = int.Parse(Console.ReadLine());
        }
    }

    public void InMang()
    {
        Console.WriteLine("Mang:");

        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }

        Console.WriteLine();
    }

    public int TimMax()
    {
        int max = a[0];

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] > max)
                max = a[i];
        }

        return max;
    }

    public int TimMin()
    {
        int min = a[0];

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] < min)
                min = a[i];
        }

        return min;
    }

    public bool LaSoNguyenTo(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }

        return true;
    }

    public int[] MangSoNguyenTo()
    {
        List<int> ketQua = new List<int>();

        for (int i = 0; i < a.Length; i++)
        {
            if (LaSoNguyenTo(a[i]))
            {
                ketQua.Add(a[i]);
            }
        }

        return ketQua.ToArray();
    }

    public static void Run()
    {
        Bai15 bai = new Bai15();

        bai.NhapMang();

        bai.InMang();

        Console.WriteLine("Max = " + bai.TimMax());
        Console.WriteLine("Min = " + bai.TimMin());

        int[] soNguyenTo = bai.MangSoNguyenTo();

        Console.Write("Mang so nguyen to: ");

        for (int i = 0; i < soNguyenTo.Length; i++)
        {
            Console.Write(soNguyenTo[i] + " ");
        }

        Console.WriteLine();
    }
}