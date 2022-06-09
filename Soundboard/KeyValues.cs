using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SQLite;

namespace Soundboard
{
    class KeyValues
    {
        public static Dictionary<Keys, string> KeyDescriptions()
        {
            Dictionary<Keys, string> DENamen = new Dictionary<Keys, string>();

            DENamen.Add(Keys.LControlKey, "STRG LINKS");
            DENamen.Add(Keys.RControlKey, "STRG RECHTS");
            DENamen.Add(Keys.LShiftKey, "UMSCH LINKS");
            DENamen.Add(Keys.RShiftKey, "UMSCH RECHTS");
            DENamen.Add(Keys.LWin, "WIN LINKS");
            DENamen.Add(Keys.RWin, "WIN RECHTS");
            DENamen.Add(Keys.LMenu, "ALT");
            DENamen.Add(Keys.RMenu, "ALT-GR");
            DENamen.Add(Keys.Space, "LEERTASTE");
            DENamen.Add(Keys.CapsLock, "CAPS LOCK");
            DENamen.Add(Keys.Tab, "TAB");
            DENamen.Add(Keys.Enter, "ENTER");
            DENamen.Add(Keys.Back, "BACKSPACE");
            DENamen.Add(Keys.Delete, "ENTF");
            DENamen.Add(Keys.Insert, "EINFG");
            DENamen.Add(Keys.Home, "POS1");
            DENamen.Add(Keys.End, "ENDE");
            DENamen.Add(Keys.PageUp, "BILD AUF");
            DENamen.Add(Keys.PageDown, "BILD AB");
            DENamen.Add(Keys.PrintScreen, "DRUCK");
            DENamen.Add(Keys.Scroll, "ROLLEN");
            DENamen.Add(Keys.Up, "PFEIL HOCH");
            DENamen.Add(Keys.Left, "PFEIL LINKS");
            DENamen.Add(Keys.Right, "PFEIL RECHTS");
            DENamen.Add(Keys.Down, "PFEIL RUNTER");
            DENamen.Add(Keys.Escape, "ESCAPE");

            DENamen.Add(Keys.NumLock, "NUM LOCK");
            DENamen.Add(Keys.NumPad0, "NUM 0");
            DENamen.Add(Keys.NumPad1, "NUM 1");
            DENamen.Add(Keys.NumPad2, "NUM 2");
            DENamen.Add(Keys.NumPad3, "NUM 3");
            DENamen.Add(Keys.NumPad4, "NUM 4");
            DENamen.Add(Keys.NumPad5, "NUM 5");
            DENamen.Add(Keys.NumPad6, "NUM 6");
            DENamen.Add(Keys.NumPad7, "NUM 7");
            DENamen.Add(Keys.NumPad8, "NUM 8");
            DENamen.Add(Keys.NumPad9, "NUM 9");
            DENamen.Add(Keys.Add, "PLUS");
            DENamen.Add(Keys.Subtract, "MINUS");
            DENamen.Add(Keys.Divide, "GETEILT");
            DENamen.Add(Keys.Decimal, "DEZIMAL");
            DENamen.Add(Keys.Separator, "SEPERATOR");
            DENamen.Add(Keys.Multiply, "STERN");

            return DENamen;
        }
    }
}
