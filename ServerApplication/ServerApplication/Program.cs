﻿using System;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using ProxyLibrary;
using System.Threading;

// MSSQL
using System.Data.SqlClient;

namespace ServerApplication
{
    class Server
    {
        // private static readonly AutoResetEvent autoRestEvent = new AutoResetEvent(false);
        // private static readonly Service _service = new Service();

        private static SqlConnection myConnection = null;
        private static SqlDataReader myReader;
        public static void Main()
        {
            // _service.OnMessageRecieved = OnMessage_Received;
            // _service.StartReceiving();
            HttpChannel http = new HttpChannel(4545);
            ChannelServices.RegisterChannel(http, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Proxy), "pass123", WellKnownObjectMode.Singleton);

            // Connect to MSSQL
            String userid = "sa";
            String password = "aA1TSgofwYA";
            String server = "mssql.mssqldemo.svc.cluster.local";
            String sqlCmd = "select Id, Name from Customers";
            try {
                string myConnectString = "user id=" + userid + ";password=" + password + ";Database=myContacts;Server=" + server + ";Connect Timeout=30";
                myConnection = new SqlConnection(myConnectString);
                myConnection.Open();
                if (myConnection == null) {  
                    Console.WriteLine("OPEN NULL VALUE =====================");  
                    return;  
                }
                Console.WriteLine("EXECUTING .. " + sqlCmd);
                SqlCommand myCmd = new SqlCommand(sqlCmd);
                if (myCmd == null) {
                    Console.WriteLine("NULL VALUE...");
                } else {
                    myCmd.Connection = myConnection;
                    myCmd.ExecuteNonQuery();
                    myReader = myCmd.ExecuteReader();
                    if (!myReader.Read()) {  
                        myReader.Close();  
                        //return "";  
                    }
                    int nCol = myReader.FieldCount;
                    string outstr = "";
                    object[] values = new Object[nCol];
                    myReader.GetValues(values);
                    for (int i = 0; i < values.Length; i++) {
                        string coldata = values[i].ToString();
                        coldata = coldata.TrimEnd();
                        outstr += coldata + ",";
                    }
                    Console.WriteLine("Result: "+ outstr);
                }
            } catch (Exception es) {  
                Console.WriteLine("[Error WITH DB CONNECT...] " + es.Message);  
            }

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
