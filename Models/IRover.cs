using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Models
{
    public interface IRover
    {
        int GetPositionX();
        int GetPositionY();
        int GetOrientation();
        void SetOrientation(int orientation);
        void LoadXYPosition(int limitX, int limitY);
        //void Move(int movementType);
        void Move(int x, int y);
       
    }
}
