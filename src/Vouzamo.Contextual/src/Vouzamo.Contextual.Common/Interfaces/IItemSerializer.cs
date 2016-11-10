namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IItemSerializer
    {
        T Serialize<T>(IItem item);
    }
}
