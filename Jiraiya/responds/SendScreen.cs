using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace xClient.responds
{
    [Serializable]
    public class SendScreen : respond
    {
        public List<Rectangle> rectangle;
        public List<Stream> image;
        public Rectangle bounds;
        public Point cursor;
        public SendScreen(List<Rectangle> r, List<Stream> b)
        {
            image = b;
            rectangle = r;
        }
    }
}

