using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VolupiaChat.Controls
{
    class RoundButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            var graphics = new GraphicsPath();
            graphics.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            Region = new System.Drawing.Region(graphics);
            base.OnPaint(pevent);
        }
    }
}
