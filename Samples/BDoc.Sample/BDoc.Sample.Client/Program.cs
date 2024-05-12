using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BDoc.Sample.Client;

internal class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddBDoc();

        await builder
            .Build()
            .RunAsync();
    }
}
