using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace TrumperGame
{
    class Pipe
    {
        public char type;
        public int[] access = new int[4];
        public int Rads;
        public bool decaying;
        public Timer timer = new Timer();

        //I need the x and y for the light if its decayed
        public int xPos;
        public int yPos;

        public Pipe(char type, int difficulty)
        {
            this.type = type;
            Rads = 0;
            access = findAccess(type);
            decaying = false;
            xPos = 0;
            yPos = 0;

            // Tell the timer what top do when it elapses
            this.timer.Elapsed += new ElapsedEventHandler(myEvent);
            // Set it to go off every three seconds
            this.timer.Interval = difficulty;
        }

        // Implement a call with the right signature for events going off
        private void myEvent(object source, ElapsedEventArgs e)
        {
            if (this.Rads < 3)
            {
                this.Rads++;
            }
            else
            {
                this.timer.Stop();
            }
        }
    

        /*
         * { up, down, left, right }
         * 
         */ 
        private int[] findAccess(char type)
        {
            if (type == 'x')
            {
                return new int[4] { 0, 0, 1, 1 };
            }
            else if (type == 'y')
            {
                return new int[4] { 1, 1, 0, 0 };
            }
            else if (type == '1')
            {
                return new int[4] { 0, 1, 0, 1 };
            }
            else if (type == '2')
            {
                return new int[4] { 0, 1, 1, 0 };
            }
            else if (type == '3')
            {
                return new int[4] { 1, 0, 0, 1 };
            }
            else if (type == '4')
            {
                return new int[4] { 1, 0, 1, 0 };
            }
            else if (type == '5')
            {
                return new int[4] { 1, 1, 0, 1 };
            }
            else if (type == '6')
            {
                return new int[4] { 1, 1, 1, 0 };
            }
            else if (type == '7')
            {
                return new int[4] { 1, 0, 1, 1 };
            }
            else if (type == '8')
            {
                return new int[4] { 0, 1, 1, 1 };
            }
            else if (type == '9')
            {
                return new int[4] { 1, 1, 1, 1 };
            }
            else
            {
                return new int[4] { 0, 0, 0, 0 };
            }

        }
    }
}
