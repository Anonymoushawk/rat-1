using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace xClient.Utils.ScreenCapture
{
    class IBcodec2
    {
        int cou = 0;
        Stopwatch sw = new Stopwatch();
        public Bitmap Old;
        Bitmap New;

        BitmapData NewData = null;
        BitmapData OldData = null;
        const int nbpp = 4;

        public List<Rectangle> Blocks;
        public List<Stream> BlocksData;
        public int quality = 30;
        public void Code(Bitmap N, int q)
        {
           // if (!sw.IsRunning)
          //  {
                sw.Start();
          //  }
            New = N;
            int width = New.Width;
            int height = New.Height;
            int left = width;
            int right = 0;
            int top = height;
            int bottom = 0;

            List<Rectangle> horizantals = new List<Rectangle>();
            Blocks = new List<Rectangle>();
            BlocksData = new List<Stream>();

            int lastX = -1, lastY = -1;
            if (Old == null || quality != q)
            {
                //if ther is no old image to compare to , just send the new one

                Old = New ;
                quality = q;
                BlocksData.Add(CaptureScreen.Compress(New, q));
                Blocks.Add(new Rectangle(0, 0, width, height));
            }

            else
            {
                try
                {
                    NewData = New.LockBits(
                                        new Rectangle(0, 0, New.Width, New.Height),
                                        ImageLockMode.ReadOnly, New.PixelFormat);

                 
                    OldData = Old.LockBits(
                        new Rectangle(0, 0, Old.Width, Old.Height),
                        ImageLockMode.ReadOnly, Old.PixelFormat);


                    int strideNew = NewData.Stride / nbpp;
                    int strideOld = OldData.Stride / nbpp;


                    IntPtr scanNew0 = NewData.Scan0;
                    IntPtr scanOld0 = OldData.Scan0;
                    Console.WriteLine("setting up :" + sw.ElapsedMilliseconds + " ms");
                    sw.Reset();

                    sw.Start();
                    unsafe
                    {
                        int* pNew = (int*)(void*)scanNew0;
                        int* pPrev = (int*)(void*)scanOld0;


                        
                        // we are going to scan from top to bottom , left to right
                        // whene we finde something has changed we see if the position 
                        // of the that pixel if its the extremest , we set it as a border to get 
                        // the changed area

                        for (int y = 0; y < New.Height; ++y)
                        {


                            for (int x = 0; x < Old.Width; ++x)
                            {
                                if ((pNew + x)[0] != (pPrev + x)[0])
                                {
                                    if (x < left) { left = x; }
                                    if (x > right) { right = x; }
                                    if (y < top) { top = y; }
                                    if (y > bottom) { bottom = y; }
                                    lastY = y;
                                }


                            }

                            if ((y - lastY > 20 && lastY != -1) || (bottom == New.Height - 1 && top == 0))
                            {
                                horizantals.Add(new Rectangle(left, top, right - left, bottom - top + 1));
                                left = width;
                                right = 0;
                                top = height;
                                bottom = 0;
                                lastY = -1;

                            }
                            pNew += strideNew;
                            pPrev += strideOld;
                        }
                        Console.WriteLine("first scan :" + sw.ElapsedMilliseconds + " ms");
                        sw.Reset();
                        sw.Start();



                        //get small rectangles


                        for (int i = 0; i < horizantals.Count; i++)
                        {
                            left = horizantals[i].X + horizantals[i].Width;
                            right = horizantals[i].X;
                            for (int x = horizantals[i].X; x < horizantals[i].X + horizantals[i].Width + 1; x++)
                            {
                                pNew = (int*)(void*)scanNew0;
                                pPrev = (int*)(void*)scanOld0;

                                for (int y = horizantals[i].Y; y < horizantals[i].Top + horizantals[i].Bottom; ++y)
                                {
                                    if ((pNew + x)[0] != (pPrev + x)[0])
                                    {
                                        if (x <= left) { left = x; }
                                        if (x >= right) { right = x; }
                                        lastX = x;
                                    }

                                    pNew += strideNew;
                                    pPrev += strideOld;
                                }

                                if ((x - lastX > 10 && lastX != -1) || (left == horizantals[i].X && right + 1 == horizantals[i].X + horizantals[i].Width + 1))
                                {
                                    Blocks.Add(new Rectangle(left, horizantals[i].Top, right - left, horizantals[i].Bottom - horizantals[i].Top));
                                    left = horizantals[i].X + horizantals[i].Width;
                                    right = horizantals[i].X;
                                    lastX = -1;



                                }

                            }
                        }

                        Console.WriteLine("cutting :" + sw.ElapsedMilliseconds + " ms");
                        sw.Reset();
                        sw.Start();



                    }
                }
                catch (Exception ex)
                {
         
                }
                finally
                {
                    if (NewData != null)
                    {
                        New.UnlockBits(NewData);
                    }
                    if (OldData != null)
                    {
                        Old.UnlockBits(OldData);
                    }
                }
                for (int i = 0; i < Blocks.Count; i++)
                {
                    try
                    {
                        Rectangle bounds = Blocks[i];
                        bounds.Width = bounds.Width == 0 ? 1 : bounds.Width = bounds.Width;
                        bounds.Height = bounds.Width == 0 ? 1 : bounds.Height = bounds.Height;

                        Bitmap diff = new Bitmap(bounds.Width, bounds.Height);
                        Graphics _graphics = Graphics.FromImage(diff);

                        if (bounds.Width > 0) _graphics.DrawImage(New, 0, 0, bounds, GraphicsUnit.Pixel);

                        BlocksData.Add(CaptureScreen.Compress(diff, q));
                        _graphics.Flush();
                        _graphics.Dispose();
                        diff.Dispose();
                    }
                    catch (Exception ex)
                    {
                        //  Console.WriteLine(Blocks[i]);
                           Console.WriteLine("code : "+ex.TargetSite+" | "+ex.Message);
                    }
                }
                Console.WriteLine("creating pics :" + sw.ElapsedMilliseconds + " ms");
                sw.Reset();
                 
                 Old = New ;
               
             }
            cou++;
         //   if (sw.ElapsedMilliseconds >= 1000)
          //  {
         //       Console.WriteLine("frames :" + cou+ " per "+sw.ElapsedMilliseconds/1000+" secondes");
                Console.WriteLine("--------------------------New lap ----------------------");
        //        sw.Reset();
        //        sw.Stop();
        //        cou = 0;
        //    }

        }






    }
}
