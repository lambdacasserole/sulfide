﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace Sulfide
{
    public partial class IdeForm : Form
    {
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

        private void IdeForm_Load(object sender, EventArgs e)
        {
            // Customize theme and apply to docking system.
            var theme = new VS2012LightTheme();
            ideDockingPanel.Theme = theme;

            // Open default code document.
            var defaultCodeDocument = new CodeDocument {Text = "New File 1"};
            OpenDocument(defaultCodeDocument);
        }
    }
}
