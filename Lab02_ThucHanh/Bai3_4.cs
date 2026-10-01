using System;

public class ConsoleMenu
{
    // Khhai báo Event xử lý khi người dùng chọn menu
    public event Action<int>? Choose;

    public void RunMenu()
    {
        int chon = -1;
        do
        {
            Console.WriteLine("\n========== MENU ==========");
            Console.WriteLine("1. Giải phương trình bậc 2");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");
            
            if (int.TryParse(Console.ReadLine(), out chon))
            {
                if (chon == 0) break;
                // Bắn sự kiện Choose
                Choose?.Invoke(chon);
            }
        } while (chon != 0);
    }
}

public class PTBac2Console
{
    public void GiaiPTB2()
    {
        Console.WriteLine("\n[GIẢI PHƯƠNG TRÌNH BẬC 2: ax^2 + bx + c = 0]");
        Console.Write("Nhập a: "); double a = double.Parse(Console.ReadLine()!);
        Console.Write("Nhập b: "); double b = double.Parse(Console.ReadLine()!);
        Console.Write("Nhập c: "); double c = double.Parse(Console.ReadLine()!);

        if (a == 0)
        {
            if (b == 0) Console.WriteLine(c == 0 ? "Phương trình vô số nghiệm" : "Phương trình vô nghiệm");
            else Console.WriteLine($"Nghịệm bậc 1: x = {-c / b}");
            return;
        }

        double delta = b * b - 4 * a * c;
        if (delta < 0) Console.WriteLine("Phương trình vô nghiệm.");
        else if (delta == 0) Console.WriteLine($"Phương trình có nghiệm kép x1 = x2 = {-b / (2 * a)}");
        else
        {
            double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
            Console.WriteLine($"Nghiệm x1 = {x1}, x2 = {x2}");
        }
    }
}

public class Bai3_4
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        ConsoleMenu menu = new ConsoleMenu();
        PTBac2Console pt2 = new PTBac2Console();

        // Đăng ký sự kiện
        menu.Choose += (option) =>
        {
            if (option == 1) pt2.GiaiPTB2();
        };

        menu.RunMenu();
    }
}