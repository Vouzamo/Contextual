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

    public interface IWhat : IContextPillar
    {
        DeviceType DeviceType { get; }
    }

    public interface IWhen : IContextPillar
    {
        string TimeZone { get; }
        DateTime Now { get; }
    }

    public interface IWhere : IContextPillar
    {
        string CultureCode { get; }
    }

    public interface IWhy : IContextPillar
    {
        string Scheme { get; }
        string Host { get; }
        int? Port { get; }
    }
}