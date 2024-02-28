using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace taskss
{
    public class ScreenShot
    {
        private Size _size;
        private string _path;
        private Bitmap _bpm;

        public ScreenShot(string path)
        {
            SetProcessDPIAware();
            _path = path;   
        }

        [DllImport("user32.dll")]
        static extern bool SetProcessDPIAware();       

        public void GetMonitorSize()
        {
            IntPtr hwnd = Process.GetCurrentProcess().MainWindowHandle;
            using Graphics g = Graphics.FromHwnd(hwnd);
            _size =  new Size((int)g.VisibleClipBounds.Width, (int)g.VisibleClipBounds.Height);
        }

        public void TakeScreenshot()
        {
            GetMonitorSize();
            Bitmap bmp = new Bitmap(_size.Width, _size.Height);
            using Graphics graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen(Point.Empty, Point.Empty, bmp.Size);
            _bpm = bmp;
        }

        public void SaveScreenShotPng(string title)
        {
            _bpm.Save($"{_path}/{title}.png");
        }
    }
}
