using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Schedule_flight
{
    public class Program
    {
        public static void Main(string[] args)
        {
            QueueConsumers.Consumer("AddDiscountQueue");
            QueueConsumers.Consumer("AddAirlineBlockQueue");
            QueueConsumers.Consumer("AddAirlineUnBlockQueue");
            QueueConsumers.Consumer("DeleteDiscountQueue");
            QueueConsumers.Consumer("AddFlightQueue");
          CreateWebHostBuilder(args).Build().Run();
           
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
