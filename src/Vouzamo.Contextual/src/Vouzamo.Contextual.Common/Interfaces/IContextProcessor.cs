using Microsoft.AspNetCore.Http;

namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IContextProcessor
    {
        IContext Process(HttpRequest request);
    }
}