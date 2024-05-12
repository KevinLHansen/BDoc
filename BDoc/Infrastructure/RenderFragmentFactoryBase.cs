using Microsoft.AspNetCore.Components.Rendering;

namespace BDoc.Infrastructure;

/// <summary>
/// Base class for any factory implementation which needs to create RenderFragment instances from code
/// </summary>
public abstract class RenderFragmentFactoryBase
{
    // This is left empty intentionally, see https://stackoverflow.com/questions/72779725/creating-a-plain-non-component-class-using-a-razor-file
    protected virtual void BuildRenderTree(RenderTreeBuilder builder)
    { }
}
