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

        IClipboardStrategy ClipboardStrategy { get; }

        IPrintingStrategy PrintingStrategy { get; }

        IHistoryStrategy HistoryStrategy { get; }

        string Text { get; set; }

        void Show(DockPanel dockPanel, DockState dockState);

        void Close();
    }
}
