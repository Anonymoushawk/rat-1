using System;
using System.Collections.Generic;
using System.Text;

namespace Jiraiya.commands
{
    [Serializable]
    public class GetScreen : command
    {
       public int quality, width, hight;

        public GetScreen(int q, int w, int h)
        {
            this.quality = q;
            this.width = w;
            this.hight = h;
        }
    }
}
