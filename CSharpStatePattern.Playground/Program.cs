using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using CSharpStatePattern.PoC;
//using CSharpStatePattern.Generic;
using CSharpStatePattern.Partials;

namespace CSharpStatePattern.Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Print(OnOff.On);
            Print(OnOff.Off);
            Console.ReadKey();
        }

        private static void Print(OnOff state)
        {
            byte stateByte = state;
            OnOff.Values stateValue = state;
            Console.WriteLine("State = {0}", state);
            Console.WriteLine("Byte = {0}", stateByte);
            Console.WriteLine("Value = {0}", stateValue);
            Console.WriteLine("DisplayText = {0}", state.DisplayText);
            Console.WriteLine();
        }
    }
}
