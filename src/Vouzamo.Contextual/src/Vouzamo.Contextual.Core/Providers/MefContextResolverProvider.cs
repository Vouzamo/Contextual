using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using Vouzamo.Contextual.Common.Interfaces;
using Vouzamo.Contextual.Core.Extensions;

namespace Vouzamo.Contextual.Core.Providers
{
    public class MefContextResolverProvider : IContextResolverProvider
    {
        private ContainerConfiguration Configuration { get; set; }

        public MefContextResolverProvider(string resolversPath)
        {
            Configure(resolversPath);
        }

        private void Configure(string path)
        {
            var conventions = new ConventionBuilder();

            conventions.ForTypesDerivedFrom<IContextResolver<IWho>>()
                .Export<IContextResolver<IWho>>()
                .Shared();

            conventions.ForTypesDerivedFrom<IContextResolver<IWhat>>()
                .Export<IContextResolver<IWhat>>()
                .Shared();

            conventions.ForTypesDerivedFrom<IContextResolver<IWhere>>()
                .Export<IContextResolver<IWhere>>()
                .Shared();

            conventions.ForTypesDerivedFrom<IContextResolver<IWhen>>()
                .Export<IContextResolver<IWhen>>()
                .Shared();

            conventions.ForTypesDerivedFrom<IContextResolver<IWhy>>()
                .Export<IContextResolver<IWhy>>()
                .Shared();

            Configuration = new ContainerConfiguration()
                .WithAssembliesInPath(path, conventions);
        }

        public IEnumerable<IContextResolver<T>> LoadResolvers<T>() where T : IContextPillar
        {
            using (var container = Configuration.CreateContainer())
            {
                return container.GetExports<IContextResolver<T>>();
            }
        }
    }
}
