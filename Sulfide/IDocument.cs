using WeifenLuo.WinFormsUI.Docking;

namespace Sulfide
{
    /// <summary>
    /// Represents a document that can be opened in the editor.
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// Gets the save strategy for the document.
        /// </summary>
        ISaveStrategy SaveStrategy { get; }

        /// <summary>
        /// Gets the clipboard strategy for the document.
        /// </summary>
        IClipboardStrategy ClipboardStrategy { get; }

        /// <summary>
        /// Gets the printing strategy for the document.
        /// </summary>
        IPrintingStrategy PrintingStrategy { get; }

        /// <summary>
        /// Gets the history strategy for the document.
        /// </summary>
        IHistoryStrategy HistoryStrategy { get; }

        /// <summary>
        /// Gets or sets the window title for the document.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Shows the document in the editor.
        /// </summary>
        /// <param name="dockPanel">The dock panel to show the document in.</param>
        /// <param name="dockState">The initial dock state of the document.</param>
        void Show(DockPanel dockPanel, DockState dockState);

        /// <summary>
        /// Closes the document in the editor.
        /// </summary>
        void Close();
    }
}
