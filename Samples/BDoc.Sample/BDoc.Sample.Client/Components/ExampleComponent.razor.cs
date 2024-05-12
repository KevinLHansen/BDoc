using Microsoft.AspNetCore.Components;

namespace BDoc.Sample.Client.Components;

public partial class ExampleComponent : ComponentBase
{
    [Parameter]
    public string Text { get; set; } = string.Empty;
}
