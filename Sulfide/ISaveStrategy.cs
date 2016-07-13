namespace Sulfide
{
    /// <summary>
    /// Represents a save strategy used with an implementation of <see cref="IDocument"/>.
    /// </summary>
    public interface ISaveStrategy
    {
        /// <summary>
        /// Saves the document.
        /// </summary>
        void Save();

        /// <summary>
        /// Shows a dialog for saving the document.
        /// </summary>
        void SaveAs();
    }
}
