using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Lab01
{
    public class Button : Window
    {
        public Button(int top, int left) : base(top, left)
        {

        }
        public override void DrawWindow()
        {
            Console.WriteLine("Drawinf a button at {0}, {1}\n", top, left);
        }
    }
}