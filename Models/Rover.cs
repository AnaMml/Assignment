using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
{
    internal class Rover
    {
        Position position;


        int PositionX {get;set;}
        int PositionY {get;set;}
        int Orientation { get;set;}


        public Rover(int limitX, int limitY)
        {
            LoadXYPosition(limitX, limitY);
        }
        public void LoadXYPosition(int limitX, int limitY)
        {
            this.PositionX = GetRandomValues(limitX);
            this.PositionY = GetRandomValues(limitY);
            SetOrientation(29);
            this.Orientation = GetOrientation();
        }
        int GetRandomValues(int limit)
        {
            Random random = new Random();
            return random.Next(limit);
        }

        public void SetOrientation(int orientation)
        {
            this.Orientation = orientation; 
        }


       
        public int GetPositionX()
        {
           return this.PositionX;
        }

        public int GetPositionY()
        {
            return this.PositionY;
        }

        public int GetOrientation()
        {
            return this.Orientation;
        }

        public void Move(int x, int y)
        {
            PositionX += x;
            PositionY += y;
        }

    }
}

       