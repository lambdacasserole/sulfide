namespace Sulfide
{
    /// <summary>
    /// Represents a clipboard strategy used with an implementation of <see cref="IDocument"/>.
    /// </summary>
    public interface IClipboardStrategy
    {
        /// <summary>
        /// Performs a cut action on the document.
        /// </summary>
        void Cut();

        /// <summary>
        /// Performs a copy action on the document.
        /// </summary>
        void Copy();

        /// <summary>
        /// Performs a paste action on the document.
        /// </summary>
        void Paste();

        /// <summary>
        /// Selects the entire contents of the document.
        /// </summary>
        void SelectAll();
    }
}
