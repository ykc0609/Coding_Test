using System;
using System.Collections;
namespace coding_test
{
    public class Rover
    {
        // Using Hashtable to transfer direction from character into numerical.
        private Hashtable DirectionMap = new Hashtable() { { 'N', 0 }, { 'E', 1 }, { 'S', 2 }, { 'W', 3 } };
        // Initial facing direction.
        public int facing = -1;
        // initial position.
        public int x = 0;
        public int y = 0;

        // Set initial head 
        public void SetFace(char direction)
        {
            this.facing = (int)DirectionMap[direction];
        }

        // Set initial position
        public void SetPosition(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        // Rotate base on command
        public void Rotate(char command)
        {
            switch (command)
            {
                case 'L':
                    this.facing--;
                    if (this.facing < 0)
                    {
                        this.facing += 4;
                    }
                    break;
                case 'R':
                    this.facing++;
                    this.facing %= 4;
                    break;
                default:
                    break;
            }
        }
        // Change the position base on facing direction
        public void Walk()
        {
            switch (this.facing)
            {
                case 0:
                    this.y++;
                    break;
                case 1:
                    this.x++;
                    break;
                case 2:
                    this.y--;
                    break;
                case 3:
                    this.x--;
                    break;
                default:
                    break;
            }
        }
        // Check if the current position is out of bound or not
        public Boolean CheckValid(int x,int y)
        {
            if (this.x > x || this.x < 0 || this.y > y || this.y < 0)
            {
                return true;
            }
            return false;
        }
        
    }
}
