using System;
using System.Collections.Generic;

namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IWho : IContextPillar
    {
        Guid? UniqueId { get; }
        string Segment { get; }
        string FirstName { get; }
        string LastName { get; }
        IEnumerable<string> MiddleNames { get; }
    }
}