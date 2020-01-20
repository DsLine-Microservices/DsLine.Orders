using Autofac;
using Autofac.Extensions.DependencyInjection;
using DsLine.Core.RabbitMQ;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RawRabbit.Instantiation;
using System.Reflection;

namespace DsLine.Orders.Services.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .UseServiceProviderFactory(new AutofacServiceProviderFactory())
              .ConfigureContainer<ContainerBuilder>(builder =>
              {

                  
                  builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                      .AsImplementedInterfaces();
          
                  //  builder.AddDispatchers();
                  builder.AddRabbitMq();
                  builder.Register(s => s.Resolve<IInstanceFactory>().Create());

              })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
