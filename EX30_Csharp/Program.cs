using System;
using System.IO;

namespace Exercise30
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("\nChọn chức năng:");
                Console.WriteLine("1. Nhập số nguyên dương và số thực");
                Console.WriteLine("2. Nhập và hiển thị mảng 2 chiều số thực");
                Console.WriteLine("3. Hiển thị mảng 2 chiều từ file CSV");
                Console.WriteLine("4. Ghi mảng 2 chiều vào file CSV");
                Console.WriteLine("5. Đọc mảng 2 chiều từ file CSV và hiển thị");
                Console.WriteLine("6. Thoát");

                Console.Write("Nhập lựa chọn của bạn: ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        NhapSoNguyenDuongVaSoThuc();
                        break;
                    case 2:
                        NhapVaHienThiMang2Chieu();
                        break;
                    case 3:
                        HienThiMang2ChieuTuFileCSV();
                        break;
                    case 4:
                        GhiMang2ChieuVaoFileCSV();
                        break;
                    case 5:
                        DocVaHienThiMangTuFileCSV();
                        break;
                    case 6:
                        Console.WriteLine("Thoát chương trình.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }

        static void NhapSoNguyenDuongVaSoThuc()
        {
            int m = EditNumbers.nhapsonguyenduong();
            int n = EditNumbers.nhapsonguyenduong();
            float x = EditNumbers.nhapsothuc4byte();

            Console.WriteLine($"Giá trị của m: {m}");
            Console.WriteLine($"Giá trị của n: {n}");
            Console.WriteLine($"Giá trị của x: {x}");
        }

        static void NhapVaHienThiMang2Chieu()
        {
            int m = EditNumbers.nhapsonguyenduong();
            int n = EditNumbers.nhapsonguyenduong();
            float[,] arr = array_float_2d.nhapmangfloat2d(m, n);
            array_float_2d.hienthimangfloat2d(arr);
        }

        static void HienThiMang2ChieuTuFileCSV()
        {
            float[,] arr = array_float_2d.docmang2dfloat_file_csv("a2d.csv");
            if (arr != null)
            {
                array_float_2d.hienthimangfloat2d(arr);
            }
        }

        static void GhiMang2ChieuVaoFileCSV()
        {
            int m = EditNumbers.nhapsonguyenduong();
            int n = EditNumbers.nhapsonguyenduong();
            float[,] arr = array_float_2d.nhapmangfloat2d(m, n);
            array_float_2d.ghimang2dfloat_file_csv(arr, "a2d.csv");
        }

        static void DocVaHienThiMangTuFileCSV()
        {
            float[,] arr = array_float_2d.docmang2dfloat_file_csv("a2d.csv");
            if (arr != null)
            {
                array_float_2d.hienthimangfloat2d(arr);
            }
        }
    }

    public static class EditNumbers
    {
        public static int nhapsonguyenduong()
        {
            int num;
            while (true)
            {
                try
                {
                    Console.Write("Nhập số nguyên dương: ");
                    num = int.Parse(Console.ReadLine());
                    if (num > 0)
                    {
                        return num;
                    }
                    else
                    {
                        Console.WriteLine("Bạn phải nhập một số nguyên dương.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Định dạng không hợp lệ. Vui lòng nhập lại.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Số quá lớn. Vui lòng nhập lại.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                }
            }
        }

        public static float nhapsothuc4byte()
        {
            float num;
            while (true)
            {
                try
                {
                    Console.Write("Nhập số thực (4 byte): ");
                    num = float.Parse(Console.ReadLine());
                    return num;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Định dạng không hợp lệ. Vui lòng nhập lại.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Số quá lớn. Vui lòng nhập lại.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message}");
                }
            }
        }
    }

    public static class array_float_2d
    {
        public static float[,] nhapmangfloat2d(int m, int n)
        {
            float[,] arr = new float[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = EditNumbers.nhapsothuc4byte();
                }
            }
            return arr;
        }

        public static void hienthimangfloat2d(float[,] arr)
        {
            int m = arr.GetLength(0);
            int n = arr.GetLength(1);

            Console.WriteLine("Hiển thị mảng 2 chiều:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public static void ghimang2dfloat_file_csv(float[,] arr, string fileName)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    int m = arr.GetLength(0);
                    int n = arr.GetLength(1);

                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            writer.Write(arr[i, j]);
                            if (j < n - 1)
                            {
                                writer.Write(",");
                            }
                        }
                        writer.WriteLine();
                    }
                }
                Console.WriteLine($"Đã ghi mảng vào file {fileName} thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi ghi file: {ex.Message}");
            }
        }

        public static float[,] docmang2dfloat_file_csv(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    int row = 0;
                    int col = 0;

                    // Đếm số dòng và số cột trong file
                    while ((line = reader.ReadLine()) != null)
                    {
                        col = line.Split(',').Length;
                        row++;
                    }

                    float[,] arr = new float[row, col];
                    reader.BaseStream.Seek(0, SeekOrigin.Begin); // Đưa con trỏ về đầu file

                    // Đọc dữ liệu từ file
                    string[] split;
                    for (int i = 0; i < row; i++)
                    {
                        line = reader.ReadLine();
                        split = line.Split(',');
                        for (int j = 0; j < col; j++)
                        {
                            arr[i, j] = float.Parse(split[j]);
                        }
                    }

                    Console.WriteLine($"Đã đọc mảng từ file {fileName} thành công.");
                    return arr;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
                return null;
            }
        }
    }
}
