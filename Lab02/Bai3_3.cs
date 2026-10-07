using System;

public class Bai3_3
{
    // Định nghĩa delegate so sánh hoặc dùng Func<T, T, int>
    public delegate int SoSanhDelegate<T>(T x, T y);

    public static void SapXep<T>(T[] arr, SoSanhDelegate<T> comparer)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                // Gọi delegate để so sánh
                if (comparer(arr[i], arr[j]) > 0)
                {
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

        int[] numbers = { 5, 2, 9, 1, 7 };

        Console.WriteLine("Mảng gốc: " + string.Join(" ", numbers));

        // Truyền Lambda function vào delegate để sắp xếp tăng dần
        SapXep(numbers, (a, b) => a.CompareTo(b));
        Console.WriteLine("Sắp xếp tăng dần: " + string.Join(" ", numbers));

        // Truyền Lambda để sắp xếp giảm dần
        SapXep(numbers, (a, b) => b.CompareTo(a));
        Console.WriteLine("Sắp xếp giảm dần: " + string.Join(" ", numbers));
    }
}