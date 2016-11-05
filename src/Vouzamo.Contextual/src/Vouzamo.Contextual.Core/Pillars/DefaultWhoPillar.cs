using System;
using System.Collections.Generic;
using System.Linq;
using Vouzamo.Contextual.Common.Interfaces;

namespace Vouzamo.Contextual.Core.Pillars
{
    public class DefaultWhoPillar : IWho
    {
        public Guid? UniqueId { get; protected set; }
        public string Segment { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public IEnumerable<string> MiddleNames { get; protected set; }

        public DefaultWhoPillar()
        {
            MiddleNames = Enumerable.Empty<string>();
        }
    }
}