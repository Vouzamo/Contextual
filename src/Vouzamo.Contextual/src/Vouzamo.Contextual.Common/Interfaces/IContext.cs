namespace Vouzamo.Contextual.Common.Interfaces
{
    public interface IContext
    {
        /// <summary>
        /// User information
        /// </summary>
        IWho Who { get; }

        /// <summary>
        /// Device information
        /// </summary>
        IWhat What { get; }

        /// <summary>
        /// Locale and Culture information
        /// </summary>
        IWhere Where { get; }

        /// <summary>
        /// Date & Time information
        /// </summary>
        IWhen When { get; }

        /// <summary>
        /// HTTP Request information
        /// </summary>
        IWhy Why { get; }
    }
}
