using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulfide
{
    public interface IHistoryStrategy
    {
        void Undo();

        void Redo();
    }
}
