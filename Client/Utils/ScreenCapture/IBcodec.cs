using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace xClient.Utils.ScreenCapture
{
    class IBcodec
    {
      //  Bitmap Old;  // the image we are going to use as a refrence
        byte[] _Old; // byte array contains data of "Bitmap Old"
        Bitmap New;  // the seconde image , which will be compared to the first one
 
        public List<Rectangle> Blocks; // list of rectangles to be transmeted 
        public List<Stream> BlocksData;// list of images as streams to be transmeted
        public int quality;            // compression paremeter
        PixelFormat format;

        public void Code(Bitmap N, int q)
        {
            BitmapData NewData = null;
            const int nbpp = 4; // number of bytes per pixel
            New = N;
            int width = New.Width;
            int height = New.Height;
           

            List<Rectangle> horizantals = new List<Rectangle>(); 
            Blocks = new List<Rectangle>();
            BlocksData = new List<Stream>();

            
           

         
                try
                {

                    NewData = New.LockBits(
                                        new Rectangle(0, 0, New.Width, New.Height),
                                        ImageLockMode.ReadOnly, New.PixelFormat);
  
                    int strideNew = NewData.Stride / nbpp;

                    IntPtr scanNew0 = NewData.Scan0;
                    
                    unsafe
                    {
                        byte* pScanNew0 = (byte*)scanNew0.ToInt32();

                        if (_Old == null || quality != q  )
                        {
                            //if ther is no old image to compare to , just send the new one

                            _Old = new byte[N.Width * N.Height * nbpp];
                            quality = q;
                            BlocksData.Add(CaptureScreen.Compress(New, q));
                            Blocks.Add(new Rectangle(0, 0, width, height));
                            if (format == PixelFormat.DontCare) format = N.PixelFormat;
                            fixed (byte* ptr = _Old)
                            {
                                NativeMethods.memcpy(new IntPtr(ptr), scanNew0, (uint)(N.Width * N.Height * nbpp));
                            }
                            return;
                        }

                        fixed (byte* ptr = _Old)
                        {
                           
                            int top = height;
                            int bottom = 0;
                            int lastY = -1;
                            Rectangle cBlock = new Rectangle();
                            // we are going to cutt the image in horizontal pieces each time we finde something has changed
                           
                            for (int y = 0; y < New.Height; ++y)
                            {
                                int offset = (y * N.Width * nbpp);
                                if (NativeMethods.memcmp(ptr + offset, pScanNew0 + offset, (uint)(N.Width * nbpp)) != 0)
                                {
                                    if (y < top) top = y; 
                                    if (y > bottom) bottom = y;
                                    lastY = y;
                                    NativeMethods.memcpy(ptr + offset, pScanNew0 + offset, (uint)(N.Width * nbpp));
                                    
                                }


                                if ((y > lastY && lastY != -1)|| (lastY==height-1))
                                {
                                    Rectangle b = new Rectangle(0, top, N.Width, bottom - top +1 );
                                    horizantals.Add(b);
                                    top = height;
                                    bottom = 0;
                                    lastY = -1;


                                }

                            }

                          

                        }


                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("err : " + e.Message);
                }
                finally
                {
                    if (NewData != null)
                    {
                        New.UnlockBits(NewData);
                    }
    
                }
                // now we have a list of rectangles where changes has happened , so we are going to creat small images from each rectangle
                for (int i = 0; i < horizantals.Count; i++)
                {
                    try
                    {
                        Rectangle bounds = horizantals[i];
                        bounds.Width = bounds.Width == 0 ? 1 : bounds.Width = bounds.Width;
                        bounds.Height = bounds.Width == 0 ? 1 : bounds.Height = bounds.Height;

                        Bitmap diff = new Bitmap(bounds.Width, bounds.Height);
                        Graphics _graphics = Graphics.FromImage(diff);

                        _graphics.DrawImage(New, 0, 0, bounds, GraphicsUnit.Pixel);
                       // diff.Save("C:\\Users\\islam\\Desktop\\t\\" + Guid.NewGuid().ToString("N") + ".bmp");
                        BlocksData.Add(CaptureScreen.Compress(diff, q));
                        _graphics.Flush();
                        _graphics.Dispose();
                        diff.Dispose();


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("adding exception : " + e.Message);
                    }
                  

                }

                Blocks = horizantals;
            

        }






    }
}
