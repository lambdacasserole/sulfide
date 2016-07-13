using System;
using System.IO;
using System.Windows.Forms;

namespace Sulfide
{
    public class CodeDocumentSaveStrategy : ISaveStrategy
    {
        private readonly CodeDocument _codeDocument;

        public CodeDocumentSaveStrategy(CodeDocument codeDocument)
        {
            _codeDocument = codeDocument;
        }

        public void Save()
        {
            // If document not saved yet, delegate to save as.
            if (_codeDocument.OpenFilePath == null)
            {
                SaveAs();
                return;
            }

            // Try to write file.
            try
            {
                File.WriteAllText(_codeDocument.OpenFilePath, _codeDocument.Editor.Text);
            }
            catch (Exception ex)
            {
                // TODO: Expand on this.
                MessageBox.Show("There was a problem saving your file.");
            }
        }

        public void SaveAs()
        {
            // Show dialog.
            var dialog = new SaveFileDialog()
            {
                Title = "Save File...",
                Filter = "All Files (*.*)|*.*"
            };
            var result = dialog.ShowDialog();

            // If user proceeded through dialog.
            if (result == DialogResult.OK)
            {
                _codeDocument.OpenFilePath = dialog.FileName;
                Save();
            }
        }
    }
}
