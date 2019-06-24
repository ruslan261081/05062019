using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW05062019_SingletonWatch
{
    class AsyncPrinter
    {
        Queue<string> messages = new Queue<string>();
        readonly Object key = new object();

        public void AddMessage(string m)
        {
            lock(key)
            {
                messages.Enqueue(m);
                Monitor.Pulse(key);
            }

        }
        public void CheckPrintMessage()
        {
            lock(key)
            {
                if(messages.Count > 0)
                {
                    Console.WriteLine(messages.Dequeue());
                    return;
                }
                else
                {
                    Monitor.Wait(key);
                    Console.WriteLine(messages.Dequeue());
                    return;
                }
            }
        }
    }
}
