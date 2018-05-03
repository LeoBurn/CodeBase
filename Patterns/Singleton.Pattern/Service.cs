using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Singleton.Pattern
{
    public class Service
    {
        private static object syncRoot = new object();
        private static volatile Service instance;

        public static Service Instance
        {
            get
            {
                //DoubleCheck Null because Multi-Threading
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Service();
                    }
                }
                return instance;
            }
        }
    }
}
