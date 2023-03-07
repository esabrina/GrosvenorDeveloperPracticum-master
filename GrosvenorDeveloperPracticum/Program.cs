using System;
using Application.Interfaces;
using GrosvenorDeveloperPracticum.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GrosvenorInHousePracticum
{
    class Program
    {
        static void Main()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDependencyInjectionConfiguration();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var server = serviceProvider.GetService<IServer>();
            while (true)
            {
                var unparsedOrder = Console.ReadLine();
                var output = server.TakeOrder(unparsedOrder);
                Console.WriteLine(output);
            }
        }
    }
}
