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

            conventions.ForTypesDerivedFrom<IContextResolver>()
                .Export<IContextResolver>()
                .Shared();

            Configuration = new ContainerConfiguration()
                .WithAssembliesInPath(path, conventions);
        }

        public IEnumerable<IContextResolver> LoadResolvers()
        {
            using (var container = Configuration.CreateContainer())
            {
                return container.GetExports<IContextResolver>();
            }
        }
    }
}
