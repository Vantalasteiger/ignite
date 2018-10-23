using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.Ignite.Core;
using Apache.Ignite;
using Apache.Ignite.Service;
using Apache.Ignite.Linq;
using Apache;
using Apache.Ignite.Core.Cache.Store;
using Apache.Ignite.Core.Cache;

namespace IgnitePriceServer
{
    class Program
    {
        static void Main(string[] args)
        {
            IIgnite ignite = Ignition.Start();
            int key = Int32.Parse(args[0]);

            ICache<int, string> cache = ignite.GetOrCreateCache<int, string>("test");
            cache.Put(key, $"String{key}");

            Console.ReadKey();
        }
    }
}
