using System;
using System.Collections.Generic;
using System.Text;
using xClient.Utils.ScreenCapture;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace xClient.responds
{
    [Serializable]
    public class SendScreen : Respond
    {
        public List<Rectangle> rectangle;
        public List<Stream> image;
        Rectangle bounds = Screen.PrimaryScreen.Bounds;
        public Point cursor;
        public SendScreen(List<Rectangle> r, List<Stream> b)
        {
            image = b;
            rectangle = r;
            cursor = Cursor.Position;
        }
    }
}
