using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.Ignite;
using Apache.Ignite.Service;
using Apache.Ignite.Linq;
using Apache;
using Apache.Ignite.Core.Cache.Store;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Client;

namespace IgniteClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Ignition.ClientMode = true;
            var cfg = new IgniteClientConfiguration { Host = "127.0.0.1" };
            using (var client = Ignition.StartClient(cfg))
            {
                var cache = client.GetOrCreateCache<int, string>("test");
                while (true)
                {
                    Console.WriteLine("Printing content of the cache");
                    for (int i = 0; i < 10; i++)
                    {
                        if (cache.ContainsKey(i))
                        {
                            string obj = cache.Get(i);
                            Console.WriteLine($"Key={i}, value={obj}");
                        }
                    }

                    System.Threading.Thread.Sleep(3000);
                }
            }

                
            //Ignition.StartClient()

            //// Start Ignite in client mode.
            //IIgnite ignite = Ignition.Start();

            // Create cache on all the existing and future server nodes.
            // Note that since the local node is a client, it will not 
            // be caching any data.

        }
    }
}
