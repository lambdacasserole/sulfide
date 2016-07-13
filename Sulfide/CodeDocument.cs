using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;

using ICSharpCode.AvalonEdit;

using WeifenLuo.WinFormsUI.Docking;

namespace Sulfide
{
    /// <summary>
    /// Represents a document open in a code editor tab.
    /// </summary>
    public class CodeDocument : DockContent, IDocument
    {
        private string _openFilePath;

        /// <summary>
        /// Gets the text editor containing the document.
        /// </summary>
        public TextEditor Editor { get; }

        /// <summary>
        /// Gets or sets the path of the file currently open in the editor.
        /// </summary>
        public string OpenFilePath
        {
            get { return _openFilePath; }
            set
            {
                _openFilePath = value;
                Text = Path.GetFileName(_openFilePath);
            }
        }

        public ISaveStrategy SaveStrategy { get; }

        public IClipboardStrategy ClipboardStrategy { get; }

        public IPrintingStrategy PrintingStrategy { get; }

        public IHistoryStrategy HistoryStrategy { get; }

        /// <summary>
        /// Initializes a new instance of a code document.
        /// </summary>
        public CodeDocument()
        {
            // The code editor is a WPF control that needs hosting.
            var host = new ElementHost {Dock = DockStyle.Fill};

            // Initialize WPF code editor control.
            Editor = new TextEditor
            {
                ShowLineNumbers = true,
                FontFamily = new FontFamily("Consolas"),
                FontSize = 12.75f,
                SyntaxHighlighting = SyntaxHighlightingLoader.LoadBooHighlightingDefinition()
            };

            // Add to host and add host to control.
            host.Child = Editor;
            Controls.Add(host);

            // Initialize strategies.
            SaveStrategy = new CodeDocumentSaveStrategy(this);
            ClipboardStrategy = new CodeDocumentClipboardStrategy(this);
            PrintingStrategy = new CodeDocumentPrintingStrategy(this);
            HistoryStrategy = new CodeDocumentHistoryStrategy(this);
        }
    }
}
