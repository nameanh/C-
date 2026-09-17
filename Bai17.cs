using System;
using System.Collections.Generic;

class Bai17
{
    public int[,] TaoMang(int n, int m)
    {
        Random random = new Random();

        int[,] a = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                a[i, j] = random.Next(10, 101);
            }
        }

        return a;
    }

    public void InMang(int[,] a)
    {
        int n = a.GetLength(0);
        int m = a.GetLength(1);

        Console.WriteLine("\nMang A:");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(a[i, j] + "\t");
            }

            Console.WriteLine();
        }
    }

    public void TachChanLe(
        int[,] a,
        out int[] mangChan,
        out int[] mangLe)
    {
        List<int> chan = new List<int>();
        List<int> le = new List<int>();

        int n = a.GetLength(0);
        int m = a.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (a[i, j] % 2 == 0)
                    chan.Add(a[i, j]);
                else
                    le.Add(a[i, j]);
            }
        }

        mangChan = chan.ToArray();
        mangLe = le.ToArray();
    }

    public static void Run()
    {
        Bai17 bai = new Bai17();

        Console.Write("Nhap n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Nhap m: ");
        int m = int.Parse(Console.ReadLine());

        int[,] a = bai.TaoMang(n, m);

        bai.InMang(a);

        bai.TachChanLe(
            a,
            out int[] mangChan,
            out int[] mangLe
        );

        Console.Write("\nMang so chan: ");

        for (int i = 0; i < mangChan.Length; i++)
        {
            Console.Write(mangChan[i] + " ");
        }

        Console.Write("\nMang so le: ");

        for (int i = 0; i < mangLe.Length; i++)
        {
            Console.Write(mangLe[i] + " ");
        }

        Console.WriteLine();
    }
}