using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Jiraiya.Utils
{
    public class IBcodec
    {
        static Bitmap Old;
   
        const int nbpp = 4;
        int cou = 0;
 
        Bitmap imageWithCursor;
        public List<Rectangle> Blocks;
        public List<Stream> BlocksData;
        System.Windows.Forms.Cursor cursorIco = System.Windows.Forms.Cursors.Default;
        public Bitmap Decoder(List<Stream> images, List<Rectangle> bounds , Rectangle screen , Point cursor)
        {
             
            if (Old == null)
            {
                
                Old = new Bitmap(screen.Width, screen.Height);
                Graphics g = Graphics.FromImage(Old);
                g.DrawImage((Bitmap)Bitmap.FromStream(images[0]), screen);
                g.Flush();
                g.Dispose();
                imageWithCursor = new Bitmap(Old);
                Graphics g2 = Graphics.FromImage(imageWithCursor);
                cursorIco.Draw(g2, new Rectangle(cursor.X, cursor.Y, 10, 10));
                g2.Flush();
                g2.Dispose();
                return imageWithCursor;
            }
            else {
               
                for (int i = 0; i < bounds.Count; i++)
                {
                    Bitmap rec = (Bitmap)Bitmap.FromStream(images[i]);
                    Graphics g = Graphics.FromImage(Old);
                    
                    g.DrawImage(rec, bounds[i]);
                    g.Flush();
                    g.Dispose();
                    rec.Dispose();
                }
                imageWithCursor = new Bitmap(Old);
                Graphics g2 = Graphics.FromImage(imageWithCursor);
                cursorIco.Draw(g2, new Rectangle(cursor.X, cursor.Y, 10, 10));
                g2.Flush();
                g2.Dispose();
                return imageWithCursor;

            }
        }



    }
}
