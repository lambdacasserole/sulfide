using System;
using System.Collections.Generic;
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
        public void NewCodeDocument()
        {
            var defaultCodeDocument = new CodeDocument { Text = GetNewTabText() };
            OpenDocument(defaultCodeDocument);
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

        private void EnableDisableMenuOptions()
        {
            // Enable or disable save.
            var saveEnabled = ActiveDocument?.SaveStrategy != null;
            saveAsToolStripMenuItem.Enabled = saveEnabled;
            saveToolStripButton.Enabled = saveEnabled;
            saveToolStripMenuItem.Enabled = saveEnabled;
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
    }
}
