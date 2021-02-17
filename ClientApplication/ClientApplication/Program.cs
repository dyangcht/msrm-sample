using System;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using ProxyLibrary;

namespace ClientApplication
{
    class client
    {
        static int getvalue
        {
            get
            {
                Console.Write("Enter value: ");
                return int.Parse(Console.ReadLine());
            }
        }
        public static void Main()
        {
            // get ip address from container
            // docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" container_id
            // Proxy pr = (Proxy) Activator.GetObject(typeof(Proxy), "http://172.20.117.242:4545/pass123");
            // k8s
            Proxy pr = (Proxy)Activator.GetObject(typeof(Proxy), "http://msserver1:4545/pass123");
            if (pr == null)
            {
                Console.WriteLine("Server is busy");
            } else
            {
                // int result = pr.square(getvalue);
                int result = pr.square(10);
                Console.WriteLine("Square is: " + result);
                result = pr.calculator(7, 6, 2);
                Console.WriteLine("Square is: " + result);
            }
            // Standard console application and wait for input
            // Console.ReadKey();

            // For container
            Console.ReadLine();
        }
    }
}
