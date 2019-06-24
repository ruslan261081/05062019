using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW05062019_SingletonWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Q1 - {SingletoWatch.GetInstance().GetTime()}");
            Console.WriteLine("Press Enter 1 ");
            Console.ReadKey();

            AsyncPrinter asyncPrinter = new AsyncPrinter();
            int index = 1;
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    new Thread(asyncPrinter.CheckPrintMessage).Start();
                }
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(index ++);
                    asyncPrinter.AddMessage(SingletoWatch.GetInstance().GetTime());
                    Thread.Sleep(250);
                }
            }
            Console.ReadKey();
        }
    }
}
