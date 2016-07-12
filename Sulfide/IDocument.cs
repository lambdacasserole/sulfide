using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

using WeifenLuo.WinFormsUI.Docking;

namespace Sulfide
{
    public interface IDocument
    {
        void Show(DockPanel dockPanel, DockState dockState);

        void Close();
    }
}
