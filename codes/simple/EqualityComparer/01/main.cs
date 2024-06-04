using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string str1 = "Hello";
        string str2 = "hello";

        // 自定义比较规则，忽略大小写
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        if (EqualityComparer<string>.Default.Equals(str1, str2))
        {
            Console.WriteLine("Strings are equal");
        }
        else
        {
            Console.WriteLine("Strings are not equal");
        }
    }
}