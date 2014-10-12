using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrumperGame
{
    class Particle
    {
        public int currentX;
        public int currentY;

        public Particle(int xPixels, int yPixels)
        {
            this.currentX = xPixels;
            this.currentY = yPixels;
        }

    }
}
