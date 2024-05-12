using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BDoc.Components;

public partial class ComponentParametersEditor : ComponentBase
{
    [Parameter, EditorRequired]
    public Type ComponentType { get; set; } = default!;
    [Parameter, EditorRequired]
    public IDictionary<string, object?> ComponentParameters { get; set; } = new Dictionary<string, object?>();
    [Parameter]
    public EventCallback<IDictionary<string, object?>> ComponentParametersChanged { get; set; }

    private Dictionary<string, ParameterValue> _ParameterValues = new();
    private List<PropertyInfo> _ParameterProperties = new();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        _ParameterProperties = GetParametersProperties();

        foreach (var property in _ParameterProperties)
            _ParameterValues.Add(property.Name, new ParameterValue());
    }

    private List<PropertyInfo> GetParametersProperties()
    {
        return ComponentType
            .GetProperties()
            .Where(property => property.CustomAttributes
                .Select(attributeData => attributeData.AttributeType)
                .Any(type => type == typeof(ParameterAttribute)))
            .ToList();
    }

    private async Task SetParameterValue(string name, object? value)
    {
        _ParameterValues[name] = new ParameterValue(
            value: value,
            isSet: true);

        var parameters = _ParameterValues
            .Where(x => x.Value.IsSet)
            .ToDictionary(
                keySelector: x => x.Key,
                elementSelector: x => x.Value.Value);

        await ComponentParametersChanged.InvokeAsync(parameters);
    }

    private class ParameterValue(object? value = null, bool isSet = false)
    {
        public object? Value { get; set; } = value;
        /// <summary>
        /// Used to distinguish whether value is set as <see langword="null"/> or <see langword="null"/> because it is not yet set
        /// </summary>
        public bool IsSet { get; set; } = isSet;
    }
}
