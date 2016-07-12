using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;

using ICSharpCode.AvalonEdit;

using WeifenLuo.WinFormsUI.Docking;

namespace Sulfide
{
    public class CodeDocument : DockContent, IDocument
    {
        private readonly TextEditor _codeEditor;

        public CodeDocument()
        {
            var host = new ElementHost {Dock = DockStyle.Fill};

            _codeEditor = new TextEditor
            {
                ShowLineNumbers = true,
                FontFamily = new FontFamily("Consolas"),
                FontSize = 12.75f,
                SyntaxHighlighting = SyntaxHighlightingLoader.LoadBooHighlightingDefinition()
            };

            host.Child = _codeEditor;
            Controls.Add(host);
        }
    }
}
