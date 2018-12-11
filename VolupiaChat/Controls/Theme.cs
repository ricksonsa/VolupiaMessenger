using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VolupiaChat.Controls
{
    public class Theme
    {
        public static void SetTheme()
        {
            string file = @"C: \Users\" + Environment.UserName + @"\AppData\Local\Temp\VolupiaMessenger\config.INI";

            if (!File.Exists(file))
            {
                if (!Directory.Exists(@"C: \Users\" + Environment.UserName + @"\AppData\Local\Temp\VolupiaMessenger"))
                    Directory.CreateDirectory(@"C: \Users\" + Environment.UserName + @"\AppData\Local\Temp\VolupiaMessenger");
                using (StreamWriter sr = new StreamWriter(file))
                {
                    sr.WriteLine("0");
                }
            }
            string result;

            using (StreamReader sr = new StreamReader(file))
            {
                result = sr.ReadLine();
            }

            if (string.IsNullOrEmpty(result))
                result = "0";

            Style = (ThemePack)Convert.ToInt32(result);
        }

        [Flags]
        public enum ThemePack
        {
            Default = 0,
            White = 1,
            Black = 2,
            Delicate = 4,
            Snow = 8
        }

        public static ThemePack Style { get; set; }

        public static Color GetBackColor()
        {
            Color color;

            switch (Style)
            {
                case ThemePack.Default:
                    color = Color.LightSteelBlue;
                    break;
                case ThemePack.Black:
                    color = Color.Black;
                    break;
                case ThemePack.White:
                    color = Color.White;
                    break;
                case ThemePack.Delicate:
                    color = Color.LightPink;
                    break;
                case ThemePack.Snow:
                    color = Color.Snow;
                    break;
                default:
                    color = Color.LightSteelBlue;
                    break;
            }
            return color;
        }

        public static Color SetTransparency(int A, Color color)//a=127
        {
            return Color.FromArgb(A, color.R, color.G, color.B);
        }

        public static void HoverLabel(Control c)
        {
            if (c.Font.Equals(new Font("Tahoma", 16, FontStyle.Regular)))
            {
                c.BackColor = SetTransparency(127, Color.LightGray);
            }
        }

        public static void HoverControl(Control c)
        {
            c.BackColor = SetTransparency(127, Color.LightGray);
        }

        public static void LeaveControl(Control c)
        {
            c.BackColor = Color.Transparent;
        }

        public static void LeaveLabel(Control c)
        {
            if (c.Font.Equals(new Font("Tahoma", 16, FontStyle.Regular)))
            {
                c.BackColor = Color.Transparent;
            }
        }

        public static Color GetForeColor()
        {
            Color color;

            switch (Style)
            {
                case ThemePack.Default:
                    color = Color.Black;
                    break;
                case ThemePack.Black:
                    color = Color.White;
                    break;
                case ThemePack.White:
                    color = Color.Black;
                    break;
                case ThemePack.Delicate:
                    color = Color.Black;
                    break;
                case ThemePack.Snow:
                    color = Color.Black;
                    break;
                default:
                    color = Color.Black;
                    break;
            }
            return color;
        }

    }
}
