using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Monster.Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting connections");
            for (int i = 0; i < 10; i++)
            {
                using (var client = new HttpClient())
                {
                    var result = client.GetAsync("http://aspnetmonsters.com");
                    Console.WriteLine(result.Result.StatusCode);
                }
            }
            Console.WriteLine("Connections done");
        }

        public void Fake()
        {
            var random = new Random();
            var tasks = new List<Task>();

            for (int interval = 1; interval < 10; interval++)
            {
                var count = random.Next(0, 100);

                for (int i = 0; i < count; i++)
                {
                    tasks.Add(Task.Factory.StartNew(() => {
                        try
                        {
                            var client = new WebClient();
                            var result = client.DownloadString("htt://localhost:8080/aspnettest");
                            Console.WriteLine(result);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }));
                }
                Task.WaitAll(tasks.ToArray());
                Thread.Sleep(1000);
                tasks.Clear();
            }
        }
    }
}
