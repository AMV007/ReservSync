using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace RezervSync
{
    public class InternalProgressBar:System.Windows.Forms.ProgressBar
    {
        public InternalProgressBar()
        {
            
        }
       
        protected override void  OnPaint(PaintEventArgs e)
        {            
            base.OnPaint(e);            
            System.Drawing.Font TextFont = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.Monospace),this.Height - 4);            
            string Text = this.Value.ToString();
            Size t_Size=e.Graphics.MeasureString(Text, TextFont).ToSize();
            e.Graphics.DrawString(Text, TextFont, Brushes.Black, (this.Width / 2) - (t_Size.Width / 2), (this.Height / 2) - (t_Size.Height/2));         
        }       
    }
}
