using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
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
            var printable = (IDocumentPaginatorSource) flowDocument;

            var tempFileName = Path.GetRandomFileName(); // Store XPS file at temporary path.

            try
            {
                // Write XPS document to temporary file.
                using (var doc = new XpsDocument(tempFileName, FileAccess.ReadWrite))
                {
                    var writer = XpsDocument.CreateXpsDocumentWriter(doc);
                    writer.Write(printable.DocumentPaginator);
                }
                // Customize window XAML with title of document.
                var source = Properties.Resources.PreviewWindowXaml.Replace("{{title}}", _codeDocument.Text);
                using (var reader = new XmlTextReader(new StringReader(source)))
                {
                    // Create preview window, show XPS document in the window.
                    var preview = (Window) XamlReader.Load(reader);
                    var icon = new BitmapImage(new Uri(@"pack://application:,,,/Resources/logo.png"));
                    preview.Icon = icon;
                    var documentViewer = (DocumentViewer) LogicalTreeHelper.FindLogicalNode(preview,
                        "printPreviewDocumentViewer");
                    if (documentViewer != null)
                    {
                        // Read XPS document into dynamically generated preview window.
                        using (var doc = new XpsDocument(tempFileName, FileAccess.Read))
                        {
                            documentViewer.Document = doc.GetFixedDocumentSequence();
                        }
                    }
                    preview.ShowDialog();
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
