using System;

namespace Func
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> add = Sum;
            System.Console.WriteLine(add(10, 3));

            Action<string> say = SayToUser;
            say("I m working");


        }
        static int Sum(int a, int b)
        {
            return a + b;
        }

        static void SayToUser(string msg)
        {
            Console.WriteLine("In from action delegate" + msg);
        }
    }
}
