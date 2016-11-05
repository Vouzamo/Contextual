using System.Globalization;
using Vouzamo.Contextual.Common.Interfaces;

namespace Vouzamo.Contextual.Core.Pillars
{
    public class DefaultWherePillar : IWhere
    {
        public string CultureCode { get; protected set; }

        public DefaultWherePillar(CultureInfo cultureInfo)
        {
            CultureCode = cultureInfo.ToString();
        }
    }
}