using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Vouzamo.Contextual.Common.Interfaces;

namespace Vouzamo.Contextual.Core.Items
{
    public class Page : IPage
    {
        public Guid Id { get; set; }
        public string CustomData { get; set; }
        [JsonConverter(typeof(ConcreteTypeConverter<IEnumerable<PageRegion>>))]
        public IEnumerable<IPageRegion> PageRegions { get; set; }

        public Page()
        {
            PageRegions = Enumerable.Empty<IPageRegion>();
        }
    }

    public class PageRegion : IPageRegion
    {
        public Guid Id { get; set; }
        public string CustomData { get; set; }
        [JsonConverter(typeof(ConcreteTypeConverter<IEnumerable<ComponentPresentation>>))]
        public IEnumerable<IComponentPresentation> ComponentPresentations { get; set; }

        public PageRegion()
        {
            ComponentPresentations = Enumerable.Empty<IComponentPresentation>();
        }
    }

    public class ComponentPresentation : IComponentPresentation
    {
        public Guid Id { get; set; }
        public string CustomData { get; set; }
        [JsonConverter(typeof(ConcreteTypeConverter<Component>))]
        public IComponent Component { get; set; }
        [JsonConverter(typeof(ConcreteTypeConverter<ComponentTemplate>))]
        public IComponentTemplate ComponentTemplate { get; set; }
    }

    public class Component : IComponent
    {
        public Guid Id { get; set; }
        public string CustomData { get; set; }
    }

    public class ComponentTemplate : IComponentTemplate
    {
        public Guid Id { get; set; }
        public string CustomData { get; set; }
    }
}
