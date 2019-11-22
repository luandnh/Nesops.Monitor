using Nesops.Monitor.Log.Client;
using Nesops.Monitor.Log.Client.Domains;
using System;

namespace Nesops.Monitor.LogConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            NesopsLog Log = new NesopsLog();
            NesopsAuditLog AuditLog = new NesopsAuditLog();
            Console.WriteLine("Hello World!");
            Log.Information("Console test 22/11/2019 03").AsTask().Wait();
        }
    }
}
