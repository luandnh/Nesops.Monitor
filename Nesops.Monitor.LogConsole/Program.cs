using Nesops.Monitor.Log.Client;
using Nesops.Monitor.Log.Client.Domains;
using System;

namespace Nesops.Monitor.LogConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            try
            {
                NesopsAuthorize authorize = new NesopsAuthorize();
                var result = authorize.UpdateAuthorize();
                Console.WriteLine(result);
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
            //Log.Information("Console test 17/11/2019 2");
        }
    }
}
