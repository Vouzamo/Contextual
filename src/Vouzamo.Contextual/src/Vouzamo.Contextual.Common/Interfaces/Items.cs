using System;
using System.Collections.Generic;

namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IItem
    {
        Guid Id { get; }
        string CustomData { get; }
    }

    public interface IPage : IItem
    {
        IEnumerable<IPageRegion> PageRegions { get; }
    }

    public interface IPageRegion : IItem
    {
        IEnumerable<IComponentPresentation> ComponentPresentations { get; }
    }

    public interface IComponentPresentation : IItem
    {
        IComponent Component { get; }
        IComponentTemplate ComponentTemplate { get; }
    }

    public interface IComponentTemplate : IItem
    {
        
    }

    public interface IComponent : IItem
    {
        
    }
}
