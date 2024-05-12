using BDoc.Abstractions;
using BDoc.Infrastructure.ValueEditorProviders;
using Microsoft.Extensions.DependencyInjection;

namespace BDoc;

public static class BDocExtensions
{
    public static IServiceCollection AddBDoc(this IServiceCollection services)
    {
        services.AddTransient<IValueEditorProvider, StringEditorProvider>();

        return services;
    }
}
