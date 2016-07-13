namespace Sulfide
{
    /// <summary>
    /// Represents a history strategy used with an implementation of <see cref="IDocument"/>.
    /// </summary>
    public interface IHistoryStrategy
    {
        /// <summary>
        /// Performs an undo action on the document.
        /// </summary>
        void Undo();

        /// <summary>
        /// Performs a redo action on the document.
        /// </summary>
        void Redo();
    }
}
