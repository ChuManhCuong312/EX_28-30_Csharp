using System;

namespace EX29
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("\nChọn bài tập:");
                Console.WriteLine("1. Bài tập 29.a");
                Console.WriteLine("2. Bài tập 29.b");
                Console.WriteLine("3. Bài tập 29.c");
                Console.WriteLine("4. Bài tập 29.d");
                Console.WriteLine("5. Thoát");
                Console.Write("Nhập lựa chọn của bạn: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Exercise29a();
                        break;
                    case 2:
                        Exercise29b();
                        break;
                    case 3:
                        Exercise29c();
                        break;
                    case 4:
                        Exercise29d();
                        break;
                    case 5:
                        Console.WriteLine("Kết thúc chương trình.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                        break;
                }
            }
        }

        static void Exercise29a()
        {
            double[] numbers = { 1.5, 2.7, 3.9, 4.2, 5.1 };

            double min = FindMin(numbers);
            double max = FindMax(numbers);

            Console.WriteLine("Min: " + min);
            Console.WriteLine("Max: " + max);
        }

        static void Exercise29b()
        {
            double[] numbers = { 1.5, 2.7, 3.9, 4.2, 5.1 };

            array_double_1d ob = new array_double_1d();
            double min = ob.FindMin(numbers);
            double max = ob.FindMax(numbers);

            Console.WriteLine("Min: " + min);
            Console.WriteLine("Max: " + max);
        }

        static void Exercise29c()
        {
            double[] numbers = { 1.5, 2.7, 3.9, 4.2, 5.1 };

            array_double_1d ob = new array_double_1d();
            ob.SetNumbers(numbers);
            double min = ob.FindMin();
            double max = ob.FindMax();

            Console.WriteLine("Min: " + min);
            Console.WriteLine("Max: " + max);
        }

        static void Exercise29d()
        {
            double[] numbers = { 1.5, 2.7, 3.9, 4.2, 5.1 };

            array_double_1d ob = new array_double_1d();
            ob.SetNumbers(numbers);
            double min = ob.FindMin();
            double max = ob.FindMax();

            Console.WriteLine("Min: " + min);
            Console.WriteLine("Max: " + max);
        }

        static double FindMin(double[] arr)
        {
            double min = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            return min;
        }

        static double FindMax(double[] arr)
        {
            double max = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }
    }

    public class array_double_1d
    {
        private double[] numbers;

        public double FindMin(double[] arr)
        {
            SetNumbers(arr); // Set numbers before finding min
            double min = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        public double FindMax(double[] arr)
        {
            SetNumbers(arr); // Set numbers before finding max
            double max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        public void SetNumbers(double[] arr)
        {
            numbers = arr;
        }

        public double FindMin()
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new InvalidOperationException("Mảng không tồn tại hoặc rỗng.");
            }

            double min = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        public double FindMax()
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new InvalidOperationException("Mảng không tồn tại hoặc rỗng.");
            }

            double max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }
    }
}
