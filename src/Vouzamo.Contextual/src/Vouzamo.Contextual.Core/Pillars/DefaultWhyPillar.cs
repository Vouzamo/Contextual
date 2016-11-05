using Microsoft.AspNetCore.Http;
using Vouzamo.Contextual.Common.Interfaces;

namespace Vouzamo.Contextual.Core.Pillars
{
    public class DefaultWhyPillar : IWhy
    {
        public string Scheme { get; protected set; }
        public string Host { get; protected set; }
        public int? Port { get; protected set; }

        public DefaultWhyPillar(HttpRequest request)
        {
            Scheme = request.Scheme;
            Host = request.Host.Host;
            Port = request.Host.Port;
        }
    }
}