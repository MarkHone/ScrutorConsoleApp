using Microsoft.Extensions.DependencyInjection;
using ScrutorConsoleApp;

var collection = new ServiceCollection();

// First, add our service to the collection.
collection.AddScoped<ITestService, TestService>();

// Then, decorate Decorated with the Decorator type.
collection.Decorate<ITestService, LoggingDecorator>();

// Finally, decorate Decorator with the OtherDecorator type.
// As you can see, OtherDecorator requires a separate service, IService. We can get that from the provider argument.
//collection.Decorate<ITestService>((inner, provider) => new OtherDecorator(inner, provider.GetRequiredService<IService>()));

var serviceProvider = collection.BuildServiceProvider();

Console.WriteLine("Hello, World!");

// When we resolve the IDecoratedService service, we'll get the following structure:
// OtherDecorator -> Decorator -> Decorated
var instance = serviceProvider.GetRequiredService<ITestService>();
instance.DoWork();
