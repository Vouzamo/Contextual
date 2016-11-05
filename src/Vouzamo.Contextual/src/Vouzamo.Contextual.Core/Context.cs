using Vouzamo.Contextual.Common.Interfaces;

namespace Vouzamo.Contextual.Core
{
    public class Context : IContext
    {
        public IWho Who { get; protected set; }
        public IWhat What { get; protected set; }
        public IWhere Where { get; protected set; }
        public IWhen When { get; protected set; }
        public IWhy Why { get; protected set; }

        public Context(IWho who, IWhat what, IWhere where, IWhen when, IWhy why)
        {
            Who = who;
            What = what;
            Where = where;
            When = when;
            Why = why;
        }
    }
}
