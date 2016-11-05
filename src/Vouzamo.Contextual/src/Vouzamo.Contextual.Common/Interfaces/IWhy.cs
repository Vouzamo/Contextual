namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IWhy : IContextPillar
    {
        string Scheme { get; }
        string Host { get; }
        int? Port { get; }
    }
}