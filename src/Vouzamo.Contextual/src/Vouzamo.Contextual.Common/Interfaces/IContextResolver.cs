using Microsoft.AspNetCore.Http;

namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IContextResolver<out T> where T : IContextPillar
    {
        T Resolve(HttpRequest request);
    }
}