using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

using WeifenLuo.WinFormsUI.Docking;

namespace Sulfide
{
    /// <summary>
    /// Represents a document that can be opened in the editor.
    /// </summary>
    public interface IDocument
    {
        ISaveStrategy SaveStrategy { get; }

        void Show(DockPanel dockPanel, DockState dockState);

        void Close();
    }
}
