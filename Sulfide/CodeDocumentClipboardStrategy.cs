using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulfide
{
    public class CodeDocumentClipboardStrategy : IClipboardStrategy
    {
        private readonly CodeDocument _codeDocument;

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
