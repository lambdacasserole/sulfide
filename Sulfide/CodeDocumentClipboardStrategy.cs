namespace Sulfide
{
    /// <summary>
    /// Represents a clipboard strategy designed for a <see cref="CodeDocument"/> editor.
    /// </summary>
    public class CodeDocumentClipboardStrategy : IClipboardStrategy
    {
        private readonly CodeDocument _codeDocument;

        /// <summary>
        /// Initialilzes a new instance of a clipboard strategy designed for a <see cref="CodeDocument"/> editor.
        /// </summary>
        /// <param name="codeDocument"></param>
        public CodeDocumentClipboardStrategy(CodeDocument codeDocument)
        {
            _codeDocument = codeDocument;
        }
        
        public void Cut()
        {
            _codeDocument.Editor.Cut();
        }

        public void Copy()
        {
            _codeDocument.Editor.Copy();
        }

        public void Paste()
        {
            _codeDocument.Editor.Paste();
        }
    }
}
