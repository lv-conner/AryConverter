using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        private static char[] Arr = null; 
        private static int Ary
        {
            get
            {
                if(Arr == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return Arr.Length;
                }
            }
        }
        static void Main(string[] args)
        {
            Init();
            while(true)
            {
                Console.WriteLine("*****************************************************************************************************************************************");
                Console.WriteLine("*************************************************************33进制转换*******************************************************************");
                WriterConvertMap();
                Console.WriteLine("***1.10进制转换为33进制***");
                Console.WriteLine("***2.33进制转换为10进制***");
                Console.WriteLine("***3.退出***");
                Console.WriteLine("*****************************************************************************************************************************************");
                var key = Console.ReadLine();
                if(key == "quit")
                {
                    break;
                }
                if(key == "1")
                {
                    Convert33();
                }
                if(key == "2")
                {
                    ReverseConvert();
                }
            }
            Console.WriteLine("Hello World!");
        }
        private static void WriterConvertMap()
        {
            Console.WriteLine("*****************************************************************************************************************************************");
            for (int i = 0; i < Arr.Length; i++)
            {
                Console.Write(i + "-" + Arr[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("*****************************************************************************************************************************************");
        }
        private static void Init()
        {
            var list = new List<char>()
            {
                '0',
                '1',
                '2',
                '3',
                '4',
                '5',
                '6',
                '7',
                '8',
                '9',
            };
            char s = 'A';
            list.Add(s);
            for (int i = 1; i < 26; i++)
            {
                int value = (int)s;
                value += i;
                var newChar = (char)value;
                list.Add(newChar);
            }
            list.Remove('I');
            list.Remove('O');
            list.Remove('U');
            Arr = list.ToArray();
        }
        public static void ReverseConvert()
        {
            while(true)
            {
                Console.WriteLine("请输入33进制数，输入quit退出转换！");
                var readStr = Console.ReadLine();
                if (readStr == "quit")
                {
                    break;
                }
                var readValue = readStr.ToUpper();
                bool validate = true;
                foreach (var item in readValue)
                {
                    if (!Arr.Contains(item))
                    {
                        validate = false;
                        break;
                    }
                }
                if(!validate)
                {
                    Console.WriteLine("输入值不合法！");
                }
                else
                {
                    var arr = readValue.Reverse().ToArray();
                    long rst = 0;
                    for (int i = 0; i < arr.Length; i++)
                    {
                        int value = 0;
                        for (int j = 0; j < Arr.Length; j++)
                        {
                            if (Arr[j] == arr[i])
                            {
                                value = j;
                                break;
                            }
                        }
                        rst += value * (long)Math.Pow(Ary, i);
                    }
                    Console.WriteLine("输入值\t" + readStr);
                    Console.WriteLine("转换值\t" + rst);
                }
            }
        }
        public static void Convert33()
        {
            string readString = null;
            while(true)
            {
                Console.WriteLine("请输入10进制数，输入quit退出转换！");
                readString = Console.ReadLine();
                if(readString == "quit")
                {
                    break;
                }
                if (int.TryParse(readString, out var ConvertValue))
                {
                    if (ConvertValue < Arr.Length)
                    {
                        Console.WriteLine(Arr[ConvertValue]);
                    }
                    else
                    {
                        string rst = null;
                        do
                        {
                            var remainder = ConvertValue % Arr.Length;
                            if (remainder == ConvertValue)
                            {
                                break;
                            }
                            rst += Arr[remainder];
                            ConvertValue -= remainder;
                            var quotient = ConvertValue / Arr.Length;
                            if (quotient < Arr.Length)
                            {
                                rst += Arr[quotient];
                                break;
                            }
                            ConvertValue = quotient;
                        }
                        while (true);
                        var reverse = rst.Reverse().Aggregate("", (pre, next) => pre + next);
                        Console.WriteLine("输入值\t" + readString);
                        Console.WriteLine("转换值\t" + reverse);
                    }
                }
                else
                {
                    Console.WriteLine("输入值不合法！");
                }
            }
        }

    }
}
