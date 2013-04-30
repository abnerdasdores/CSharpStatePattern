using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpStatePattern.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            OnOff on = OnOff.On;
            byte b = on;
            OnOff.Values v = on;
            Console.WriteLine("on = {0}", on);
            Console.WriteLine("b = {0}", b);
            Console.WriteLine("v = {0}", v);
            Console.ReadKey();
        }
    }
}
