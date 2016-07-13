using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace Sulfide
{
    public partial class IdeForm : Form
    {
        private const string NewTabText = "New File";

        private readonly List<IDocument> _documents;

        public IdeForm()
        {
            InitializeComponent();

            _documents = new List<IDocument>();
        }

        /// <summary>
        /// Gets the active document in the editor.
        /// </summary>
        public IDocument ActiveDocument
        {
            get { return _documents.FirstOrDefault(doc => doc == ideDockingPanel.ActiveDocument); }
        }

        /// <summary>
        /// Gets suitable tab text for a new code document.
        /// </summary>
        /// <returns></returns>
        private string GetNewTabText()
        {
            // Find unused tab number.
            var i = 1;
            while (_documents.Any(doc => doc.Text == $"{NewTabText} {i}"))
            {
                i++;
            }

            // Return tab text.
            return $"{NewTabText} {i}";
        }

        /// <summary>
        /// Opens a new code document.
        /// </summary>
        public CodeDocument NewCodeDocument()
        {
            var defaultCodeDocument = new CodeDocument { Text = GetNewTabText() };
            OpenDocument(defaultCodeDocument);

            return defaultCodeDocument; // We might want to work with this.
        }

        /// <summary>
        /// Opens a document in the editor.
        /// </summary>
        /// <param name="document">The document to open.</param>
        public void OpenDocument(IDocument document)
        {
            _documents.Add(document);
            document.Show(ideDockingPanel, DockState.Document);
        }

        /// <summary>
        /// Closes a document in the editor.
        /// </summary>
        /// <param name="document"></param>
        public void CloseDocument(IDocument document)
        {
            _documents.Remove(document);
            document.Close();
        }

        public void OpenFile()
        {
            var dialog = new OpenFileDialog()
            {
                Title = "Open File...",
                Filter = "All Files (*.*)|*.*",
                Multiselect = true,
            };
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var files = dialog.FileNames.ToDictionary(str => str, str => File.ReadAllText(str));
                foreach (var file in files)
                {
                    var t = NewCodeDocument();
                    t.OpenFilePath = file.Key;
                    t.Editor.Text = file.Value;
                }
            }
    }

        private void EnableDisableMenuOptions()
        {
            // Enable or disable save.
            var saveEnabled = ActiveDocument?.SaveStrategy != null;
            saveAsToolStripMenuItem.Enabled = saveEnabled;
            saveToolStripButton.Enabled = saveEnabled;
            saveToolStripMenuItem.Enabled = saveEnabled;

            // Enable or disable clipboard.
            var clipboardEnabled = ActiveDocument?.ClipboardStrategy != null;
            cutToolStripButton.Enabled = clipboardEnabled;
            copyToolStripButton.Enabled = clipboardEnabled;
            pasteToolStripButton.Enabled = clipboardEnabled;
            cutToolStripMenuItem.Enabled = clipboardEnabled;
            copyToolStripMenuItem.Enabled = clipboardEnabled;
            pasteToolStripMenuItem.Enabled = clipboardEnabled;

            // Enable or disable printing.
            var printingEnabled = ActiveDocument?.PrintingStrategy != null;
            printPreviewToolStripMenuItem.Enabled = printingEnabled;
            printToolStripButton.Enabled = printingEnabled;
            printToolStripMenuItem.Enabled = printingEnabled;
        }

        private void IdeForm_Load(object sender, EventArgs e)
        {
            // Customize theme and apply to docking system.
            var theme = new VS2012LightTheme();
            ideDockingPanel.Theme = theme;

            // Open default code document.
            NewCodeDocument();
        }

        private void ideDockingPanel_ActiveContentChanged(object sender, EventArgs e)
        {
            EnableDisableMenuOptions();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveDocument.SaveStrategy.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveDocument.SaveStrategy.SaveAs();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            ActiveDocument.SaveStrategy.Save();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCodeDocument();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewCodeDocument();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            ActiveDocument.ClipboardStrategy.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            ActiveDocument.ClipboardStrategy.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            ActiveDocument.ClipboardStrategy.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveDocument.ClipboardStrategy.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveDocument.ClipboardStrategy.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveDocument.ClipboardStrategy.Paste();
        }
    }
}
