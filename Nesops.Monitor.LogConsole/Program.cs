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
                //NesopsAuthorize authorize = new NesopsAuthorize();
                ////NesopsHttpClient _client = new NesopsHttpClient();
                ////_client.ResetAppSettings();
                //var result = authorize.UpdateAuthorize();

                //Console.WriteLine(result);
                int a =1, b, c = 0;
                b = a / c;

            }
            catch (Exception ex) {
                //NesopsLog Log = new NesopsLog(new NesopsHttpClient("http://localhost:49546")) ;
                //Log.Error(ex);
                Console.WriteLine(ex.StackTrace); 
            
            }
            //Log.Information("Console test 17/11/2019 2");
        }
    }
}
