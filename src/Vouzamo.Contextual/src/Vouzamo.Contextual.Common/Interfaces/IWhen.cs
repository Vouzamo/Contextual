using System;

namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IWhen : IContextPillar
    {
        string TimeZone { get; }
        DateTime Now { get; }
    }
}