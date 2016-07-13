using System;
using System.Windows.Documents;

using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;

namespace Sulfide
{
    /// <summary>
    /// Contains useful static methods for preparing <see cref="TextEditor"/> documents for printing.
    /// </summary>
    public static class DocumentPrinter
    {
        /// <summary>
        /// Produces a <see cref="FlowDocument"/> from a <see cref="TextEditor"/> instance.
        /// </summary>
        /// <param name="editor"></param>
        /// <returns></returns>
        public static FlowDocument CreateFlowDocumentForEditor(TextEditor editor)
        {
            var highlighter = editor.TextArea.GetService(typeof (IHighlighter)) as IHighlighter;
            var doc = new FlowDocument(ConvertTextDocumentToBlock(editor.Document, highlighter))
            {
                FontFamily = editor.FontFamily,
                FontSize = editor.FontSize
            };
            return doc;
        }


        /// <summary>
        /// Produces a highlighted code block from a <see cref="TextDocument"/> instance.
        /// </summary>
        /// <param name="document">The document to produce the block from.</param>
        /// <param name="highlighter">The highlighter to use.</param>
        /// <returns></returns>
        public static Block ConvertTextDocumentToBlock(TextDocument document, IHighlighter highlighter)
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            var paragraph = new Paragraph();
            foreach (var line in document.Lines)
            {
                var inlineBuilder = highlighter.HighlightLine(line.LineNumber).ToRichText();
                paragraph.Inlines.AddRange(inlineBuilder.CreateRuns());
                paragraph.Inlines.Add(new LineBreak());
            }
            return paragraph;
        }
    }
}
