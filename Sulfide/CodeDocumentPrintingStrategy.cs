using System;
using System.Windows.Documents;

namespace Sulfide
{
    /// <summary>
    /// Represents a printing strategy designed for a <see cref="CodeDocument"/> editor.
    /// </summary>
    public class CodeDocumentPrintingStrategy : IPrintingStrategy
    {
        private readonly CodeDocument _codeDocument;

        /// <summary>
        /// Initializes a new instance of a printing strategy designed for a <see cref="CodeDocument"/> editor.
        /// </summary>
        /// <param name="codeDocument">The document this strategy should act on.</param>
        public CodeDocumentPrintingStrategy(CodeDocument codeDocument)
        {
            _codeDocument = codeDocument;
        }

        public void PrintPreview()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            // Show print dialog.
            var dialog = new System.Windows.Controls.PrintDialog();
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            // Adjust document according to dialog.
            var flowDocument = DocumentPrinter.CreateFlowDocumentForEditor(_codeDocument.Editor);
            flowDocument.PageHeight = dialog.PrintableAreaHeight;
            flowDocument.PageWidth = dialog.PrintableAreaWidth;


            var printable = (IDocumentPaginatorSource) flowDocument;
            dialog.PrintDocument(printable.DocumentPaginator, _codeDocument.Text);
        }
    }
}
