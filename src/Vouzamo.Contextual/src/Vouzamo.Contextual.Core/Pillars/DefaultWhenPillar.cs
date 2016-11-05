using System;
using Vouzamo.Contextual.Common.Interfaces;

namespace Vouzamo.Contextual.Core.Pillars
{
    public class DefaultWhenPillar : IWhen
    {
        public string TimeZone { get; }
        public DateTime Now { get; }

        public DefaultWhenPillar()
        {
            Now = DateTime.UtcNow;
            TimeZone = TimeZoneInfo.Utc.Id;
        }
    }
}