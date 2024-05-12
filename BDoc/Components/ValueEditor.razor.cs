using BDoc.Abstractions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BDoc.Components;

public partial class ValueEditor : ComponentBase
{
    [Inject] private IEnumerable<IValueEditorProvider> _ValueEditorProviders { get; set; } = new List<IValueEditorProvider>();

    [Parameter, EditorRequired]
    public Type ValueType { get; set; } = default!;
    [Parameter, EditorRequired]
    public object? Value { get; set; }
    [Parameter]
    public EventCallback<object?> ValueChanged { get; set; }

    private RenderFragment? _Content;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        var provider = _ValueEditorProviders.FirstOrDefault(provider => provider.ValueType == ValueType);

        if (provider is not null)
            _Content = provider.Get(Value, ValueChanged);
    }
}
