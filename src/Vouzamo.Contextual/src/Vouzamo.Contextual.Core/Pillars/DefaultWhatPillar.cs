using Vouzamo.Contextual.Common;
using Vouzamo.Contextual.Common.Interfaces;

namespace Vouzamo.Contextual.Core.Pillars
{
    public class DefaultWhatPillar : IWhat
    {
        public DeviceType DeviceType { get; protected set; }

        public DefaultWhatPillar(DeviceType deviceType)
        {
            DeviceType = deviceType;
        }
    }
}