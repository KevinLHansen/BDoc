using Microsoft.AspNetCore.Components;
using System;

namespace BDoc.Abstractions;

public interface IValueEditorProvider
{
    Type ValueType { get; }
    RenderFragment Get(object? value, EventCallback<object?> valueChanged);
}
