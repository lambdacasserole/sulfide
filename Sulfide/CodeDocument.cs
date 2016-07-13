using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;

using ICSharpCode.AvalonEdit;

using WeifenLuo.WinFormsUI.Docking;

namespace Sulfide
{
    public class CodeDocument : DockContent, IDocument
    {
        private string _openFilePath;

        public TextEditor Editor { get; }

        public string OpenFilePath
        {
            get { return _openFilePath; }
            set
            {
                _openFilePath = value;
                Text = Path.GetFileName(_openFilePath);
            }
        }

        public CodeDocument()
        {
            var host = new ElementHost {Dock = DockStyle.Fill};

            Editor = new TextEditor
            {
                ShowLineNumbers = true,
                FontFamily = new FontFamily("Consolas"),
                FontSize = 12.75f,
                SyntaxHighlighting = SyntaxHighlightingLoader.LoadBooHighlightingDefinition()
            };

            host.Child = Editor;
            Controls.Add(host);

            SaveStrategy = new CodeDocumentSaveStrategy(this);
            ClipboardStrategy = new CodeDocumentClipboardStrategy(this);
        }

        public ISaveStrategy SaveStrategy { get; }

        public IClipboardStrategy ClipboardStrategy { get; }
    }
}
