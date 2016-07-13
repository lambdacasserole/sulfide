using WeifenLuo.WinFormsUI.Docking;

namespace Sulfide
{
    /// <summary>
    /// Represents a document that can be opened in the editor.
    /// </summary>
    public interface IDocument
    {
        ISaveStrategy SaveStrategy { get; }

        IClipboardStrategy ClipboardStrategy { get; }

        IPrintingStrategy PrintingStrategy { get; }

        IHistoryStrategy HistoryStrategy { get; }

        string Text { get; set; }

        void Show(DockPanel dockPanel, DockState dockState);

        void Close();
    }
}
