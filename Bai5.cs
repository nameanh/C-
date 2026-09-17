using System;

class Bai5
{
    public static void Run()
    {
        double x = 0;
        double y = 0;
        bool daNhap = false;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
            Console.WriteLine("2. Tinh x^y");
            Console.WriteLine("3. Tinh can bac 2 cua x va y");
            Console.WriteLine("4. Thoat");

            Console.Write("Chon chuc nang: ");
            int chon;

            if (!int.TryParse(Console.ReadLine(), out chon))
            {
                Console.WriteLine("Vui long nhap so!");
                Console.ReadKey();
                continue;
            }

            switch (chon)
            {
                case 1:
                    Console.Write("Nhap x: ");
                    if (!double.TryParse(Console.ReadLine(), out x))
                    {
                        Console.WriteLine("x khong hop le!");
                        Console.ReadKey();
                        break;
                    }

                    Console.Write("Nhap y: ");
                    if (!double.TryParse(Console.ReadLine(), out y))
                    {
                        Console.WriteLine("y khong hop le!");
                        Console.ReadKey();
                        break;
                    }

                    daNhap = true;
                    Console.WriteLine("Da nhap x = {0}, y = {1}", x, y);
                    Console.ReadKey();
                    break;

                case 2:
                    if (!daNhap)
                    {
                        Console.WriteLine("Chua nhap x va y!");
                    }
                    else
                    {
                        Console.WriteLine("x^y = " + Math.Pow(x, y));
                    }

                    Console.ReadKey();
                    break;

                case 3:
                    if (!daNhap)
                    {
                        Console.WriteLine("Chua nhap x va y!");
                    }
                    else
                    {
                        if (x >= 0)
                            Console.WriteLine("Can bac 2 cua x = " + Math.Sqrt(x));
                        else
                            Console.WriteLine("Khong the tinh can x vi x < 0");

                        if (y >= 0)
                            Console.WriteLine("Can bac 2 cua y = " + Math.Sqrt(y));
                        else
                            Console.WriteLine("Khong the tinh can y vi y < 0");
                    }

                    Console.ReadKey();
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Chuc nang khong ton tai!");
                    Console.ReadKey();
                    break;
            }
        }
    }
}