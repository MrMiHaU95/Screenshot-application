using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenAppWinForms
{
    /// <summary>
    /// to zwykły panel ale z dodaną funkcją podwójnego buforowania która eliminuje migotanie(flickering) ekranu podczas paint eventu 
    /// </summary>
    class ImprovedPanel:Panel
    {
        public ImprovedPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
}
