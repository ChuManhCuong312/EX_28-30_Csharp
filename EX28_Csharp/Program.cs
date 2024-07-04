using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EX28_Csharp
{
    public class class_demo
    {
        public void Show()
        {
            Console.WriteLine("Tôi là một lớp đơn giản!");
        }

        public ushort nhapsonguyen2bytekhongdau()
        {
            ushort n = 0;
            while (true)
            {
                try
                {
                    string sz;
                    sz = Console.ReadLine();
                    n = ushort.Parse(sz);
                    break;
                }
                catch
                {
                    Console.Beep();
                }
            }
            return n;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            class_demo ob = new class_demo();
            ob.Show();
            ushort n;
            Console.WriteLine("Nhập n:");
            n = ob.nhapsonguyen2bytekhongdau();
            Console.WriteLine("n=" + n.ToString());
        }
    }
}