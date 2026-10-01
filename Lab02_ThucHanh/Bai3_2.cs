using System;

public class Bai3_2
{
    // Thuật toán sắp xếp tổng quát cho bất kỳ kiểu T nào thực thi IComparable<T>
    public static void SapXepTongQuat<T>(T[] arr) where T : IComparable<T>
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (arr[i].CompareTo(arr[j]) > 0)
                {
                    // Hoán vị
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        PhanSo[] ds = new PhanSo[]
        {
            new PhanSo(3, 4),
            new PhanSo(1, 2),
            new PhanSo(5, 2)
        };

        Console.WriteLine("Trước khi sắp xếp: " + string.Join(", ", (object[])ds));
        SapXepTongQuat(ds);
        Console.WriteLine("Sau khi sắp xếp tăng dần: " + string.Join(", ", (object[])ds));
    }
}