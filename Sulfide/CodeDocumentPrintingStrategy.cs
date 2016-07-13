using System;

namespace Sulfide
{
    /// <summary>
    /// Represents a printing strategy designed for a <see cref="CodeDocument"/> editor.
    /// </summary>
    public class CodeDocumentPrintingStrategy : IPrintingStrategy
    {
        private CodeDocument _codeDocument;

        /// <summary>
        /// Initializes a new instance of a printing strategy designed for a <see cref="CodeDocument"/> editor.
        /// </summary>
        /// <param name="codeDocument"></param>
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
            throw new NotImplementedException();
        }
    }
}
