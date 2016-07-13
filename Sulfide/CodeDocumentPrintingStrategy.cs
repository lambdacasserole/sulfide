using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulfide
{
    public class CodeDocumentPrintingStrategy : IPrintingStrategy
    {
        private CodeDocument _codeDocument;

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
