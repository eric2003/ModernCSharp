using System;
using MyDll;

namespace usedll
{
    internal class MyTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyHelloClass obj = new MyHelloClass();
            obj.SayHello();
        }
    }
}
