using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Convert33();
            Console.WriteLine("Hello World!");
        }
        public static void ReverseConvert()
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
            var arr = list.ToArray();

            var readStr = Console.ReadLine();
            
        }
        public static void Convert33()
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
            var arr = list.ToArray();
            Console.WriteLine(list.Aggregate("", (pre, next) => pre + ";" + next));
            string readString = null;
            do
            {
                Console.WriteLine("enter int value");
                readString = Console.ReadLine();
                if (int.TryParse(readString, out var ConvertValue))
                {
                    if (ConvertValue < arr.Length)
                    {
                        Console.WriteLine(arr[ConvertValue]);
                    }
                    else
                    {
                        string rst = null;
                        do
                        {
                            var remainder = ConvertValue % (arr.Length - 1);
                            if (remainder == ConvertValue)
                            {
                                break;
                            }
                            rst += arr[remainder];

                            ConvertValue -= remainder;
                            var quotient = ConvertValue / (arr.Length - 1);
                            if (quotient < (arr.Length - 1))
                            {
                                rst += arr[quotient];
                                break;
                            }
                            ConvertValue = quotient;
                        }
                        while (true);
                        var reverse = rst.Reverse().Aggregate("", (pre, next) => pre + next);
                        Console.WriteLine(reverse);
                    }
                }
            }
            while (readString != "quit");
        }

    }
}
