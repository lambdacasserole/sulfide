using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Xml;

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
            // Prepare document for printing.
            var flowDocument = DocumentPrinter.CreateFlowDocumentForEditor(_codeDocument.Editor);
            flowDocument.PageWidth = 8*96; // A4 paper size.
            flowDocument.PageHeight = 11.5*96;
            flowDocument.PagePadding = new Thickness(50);
            flowDocument.ColumnGap = 0;
            flowDocument.ColumnWidth = flowDocument.PageWidth;
            
            var tempFileName = Path.GetRandomFileName();
            var printable = (IDocumentPaginatorSource) flowDocument;
            try
            {
                // Write XPS document to temporary file.
                using (var doc = new XpsDocument(tempFileName, FileAccess.ReadWrite))
                {
                    XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
                    writer.Write(printable.DocumentPaginator);
                }

                // Read XPS document into dynamically generated preview window.
                using (var doc = new XpsDocument(tempFileName, FileAccess.Read))
                {
                    var fixedDocumentSequence = doc.GetFixedDocumentSequence();

                    var title = $"Print Preview {_codeDocument.Text}";
                    var source = Properties.Resources.PreviewWindowXaml.Replace("@@TITLE", title);

                    using (var reader = new XmlTextReader(new StringReader(source)))
                    {
                        var preview = (Window) XamlReader.Load(reader);

                        var documentViewer = (DocumentViewer) LogicalTreeHelper.FindLogicalNode(preview, "dv1");
                        documentViewer.Document = fixedDocumentSequence;
                        
                        preview.ShowDialog();
                    }
                }
            }
            finally
            {
                // Get rid of temporary file.
                if (File.Exists(tempFileName))
                {
                    try
                    {
                        File.Delete(tempFileName);
                    }
                    catch
                    {
                        // If we can't delete the temporary file it's not the end of the world.
                    }
                }
            }
        }

        public void Print()
        {
            // Show print dialog.
            var dialog = new PrintDialog();
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            // Adjust document according to dialog.
            var flowDocument = DocumentPrinter.CreateFlowDocumentForEditor(_codeDocument.Editor);
            flowDocument.PageHeight = dialog.PrintableAreaHeight;
            flowDocument.PageWidth = dialog.PrintableAreaWidth;
            flowDocument.PagePadding = new Thickness(50);
            flowDocument.ColumnGap = 0;
            flowDocument.ColumnWidth = flowDocument.PageWidth;

            // Print document.
            var printable = (IDocumentPaginatorSource) flowDocument;
            dialog.PrintDocument(printable.DocumentPaginator, _codeDocument.Text);
        }
    }
}
