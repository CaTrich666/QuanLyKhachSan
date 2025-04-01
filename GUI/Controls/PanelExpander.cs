using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Controls
{
    public class PanelExpander
    {
        private Panel panel;
        private Timer timer;
        private bool isCollapsed;
        private int stepSize = 10;

        public PanelExpander(Panel panel, Timer timer, bool isCollapsed)
        {
            this.panel = panel;
            this.timer = timer;
            this.isCollapsed = isCollapsed;

            this.timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            if (isCollapsed)
            {
                panel.Height += stepSize;
                if (panel.Height >= panel.MaximumSize.Height)
                {
                    isCollapsed = false;
                    timer.Stop();
                }
            }
            else
            {
                panel.Height -= stepSize;
                if (panel.Height <= panel.MinimumSize.Height)
                {
                    isCollapsed = true;
                    timer.Stop();
                }
            }
        }

        public void Start()
        {
            timer.Start();
        }
    }
}
