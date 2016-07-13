using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulfide
{
    public class CodeDocumentHistoryStrategy : IHistoryStrategy
    {
        private readonly CodeDocument _codeDocument;
        
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
