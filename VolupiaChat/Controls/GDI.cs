using System;
using System.Runtime.InteropServices;

namespace VolupiaChat.Controls
{
    class GDI
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,     // x-coordinate of upper-left corner
                int nTopRect,      // y-coordinate of upper-left corner
                int nRightRect,    // x-coordinate of lower-right corner
                int nBottomRect,   // y-coordinate of lower-right corner
                int nWidthEllipse, // height of ellipse
                int nHeightEllipse // width of ellipse
            );
    }
}
