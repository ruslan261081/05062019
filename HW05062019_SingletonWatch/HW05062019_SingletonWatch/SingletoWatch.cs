using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW05062019_SingletonWatch
{
    class SingletoWatch
    {
        private static SingletoWatch _instance;
        private static object key = new object();

        private SingletoWatch()
        {

        }
        public string GetTime()
        {
            return $"Time in Israel: {DateTime.Now.ToString("HH:mm:ss tt")}"; 
        }
        public static SingletoWatch GetInstance()
        {
           if(_instance == null)
           {
                lock(key)
                {
                    if(_instance == null)
                    {
                        _instance = new SingletoWatch();
                    }
                }
           }
            return _instance;
        }
    }
}
