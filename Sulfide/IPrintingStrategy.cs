namespace Sulfide
{
    /// <summary>
    /// Represents a printing strategy used with an implementation of <see cref="IDocument"/>.
    /// </summary>
    public interface IPrintingStrategy
    {
        /// <summary>
        /// Shows a print preview for the document.
        /// </summary>
        void PrintPreview();

        /// <summary>
        /// Shows a print dialog for the document.
        /// </summary>
        void Print();
    }
}
