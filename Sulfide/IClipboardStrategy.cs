using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulfide
{
    public interface IClipboardStrategy
    {
        void Cut();

        void Copy();

        void Paste();
    }
}
