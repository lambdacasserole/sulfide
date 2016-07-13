namespace Sulfide
{
    /// <summary>
    /// Represents a history strategy designed for a <see cref="CodeDocument"/> editor.
    /// </summary>
    public class CodeDocumentHistoryStrategy : IHistoryStrategy
    {
        private readonly CodeDocument _codeDocument;

        /// <summary>
        /// Initialilzes a new instance of a history strategy designed for a <see cref="CodeDocument"/> editor.
        /// </summary>
        /// <param name="codeDocument">The document this strategy should act on.</param>
        public CodeDocumentHistoryStrategy(CodeDocument codeDocument)
        {
            _codeDocument = codeDocument;
        }

        public void Undo()
        {
            _codeDocument.Editor.Undo();
        }

        public void Redo()
        {
            _codeDocument.Editor.Redo();
        }
    }
}
