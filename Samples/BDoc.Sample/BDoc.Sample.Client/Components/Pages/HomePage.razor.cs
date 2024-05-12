using Microsoft.AspNetCore.Components;

namespace BDoc.Sample.Client.Components.Pages;

public partial class HomePage : ComponentBase
{
    private object? _Value;

    private Type _ComponentType = typeof(ExampleComponent);
    private IDictionary<string, object?> _ComponentParameters = new Dictionary<string, object?>();
}
