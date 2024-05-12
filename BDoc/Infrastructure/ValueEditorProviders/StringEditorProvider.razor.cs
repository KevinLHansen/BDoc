using BDoc.Abstractions;
using Microsoft.AspNetCore.Components;
using System;

namespace BDoc.Infrastructure.ValueEditorProviders;

public partial class StringEditorProvider : RenderFragmentFactoryBase, IValueEditorProvider
{
    public Type ValueType => typeof(string);

    public RenderFragment Get(object? value, EventCallback<object?> valueChanged)
    {
        return CreateEditor(value as string, valueChanged);
    }
}
