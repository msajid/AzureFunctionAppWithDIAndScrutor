using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureFunctionAppWithDIAndScrutor.Startup))]

namespace AzureFunctionAppWithDIAndScrutor
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
          //  builder.Services.AddSingleton<ISomeService, SomeService>();

            builder.Services.Scan(scan => scan
                            .FromAssemblyOf<ISomeService>()
                            .AddClasses(classes => classes.AssignableTo<ISomeService>())
                            .AsImplementedInterfaces()
                            .WithSingletonLifetime());

            builder.Services.Decorate<ISomeService, SimpleDecorator>();

        }
    }
}

