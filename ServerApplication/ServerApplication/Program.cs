using System;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using ProxyLibrary;
using System.Threading;

namespace ServerApplication
{
    class Server
    {
        // private static readonly AutoResetEvent autoRestEvent = new AutoResetEvent(false);
        // private static readonly Service _service = new Service();

        public static void Main()
        {
            // _service.OnMessageRecieved = OnMessage_Received;
            // _service.StartReceiving();
            HttpChannel http = new HttpChannel(4545);
            ChannelServices.RegisterChannel(http, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Proxy), "pass123", WellKnownObjectMode.Singleton);
            Console.WriteLine("Server is activate");
            Console.Read();
            Thread.Sleep(Timeout.Infinite);
            //Console.ReadLine();
        }
        /*
         * private static void OnMessage_Received(int messageId, string message)
        {
            Console.WriteLine($"Message {messageId} recieved.");
        }*/

    }
}
