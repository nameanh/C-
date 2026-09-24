using System;

class Bai10
{
    public bool KiemTraDoiXung(string chuoi)
    {
        int dau = 0;
        int cuoi = chuoi.Length - 1;

        while (dau < cuoi)
        {
            if (chuoi[dau] != chuoi[cuoi])
                return false;

            dau++;
            cuoi--;
        }

        return true;
    }

    public static void Run()
    {
        Bai10 bai = new Bai10();

        Console.Write("Nhap chuoi: ");
        string chuoi = Console.ReadLine();

        if (bai.KiemTraDoiXung(chuoi))
            Console.WriteLine("Chuoi doi xung.");
        else
            Console.WriteLine("Chuoi khong doi xung.");
    }
}