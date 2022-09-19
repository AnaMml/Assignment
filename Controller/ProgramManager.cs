using Assigment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Controller

{
    public class ProgramManager : IProgramManager
    {
        private readonly IMap _map;
        private readonly IRover _rover;
        private readonly ILog _logFile;

        public ProgramManager(IMap map, ILog logFile)
        {
            this._map = map;
            this._rover = new Rover(map.GetNoRows(),map.GetNoCols());
            this._logFile = logFile;
        }

        public void StartProgram()
        {
            Show();
            _logFile.LogValues("Program start", "START");
        }

        public int[] GetInstruction()
        {
            ConsoleKey ch = Console.ReadKey().Key;
            _logFile.LogValues(ch.ToString(), "INSTR.");
            switch (ch)
            {                
                case ConsoleKey.UpArrow:
                    return new int[] { -1, 0, 24 }; // {x, y, orientation}
                case ConsoleKey.DownArrow:
                    return new int[] { 1, 0, 25 };
                case ConsoleKey.LeftArrow:
                    return new int[] { 0, -1, 27 };                  
                case ConsoleKey.RightArrow:
                    return new int[] { 0, 1, 26 };                        
                default:
                    return new int[] {0,0,0};
            }
        }


        public string FollowUpInstruction(int[] instr)
        {
            _map.ReloadMap();
            if (_rover.GetOrientation() == instr[2])
            {
                if(VerifyInstruction(instr[0], instr[1]) == true)
                {
                    _rover.Move(instr[0], instr[1]);
                    _logFile.LogValues("New values: map(x,y) = map(" + _rover.GetPositionX() + "," + _rover.GetPositionY() + ")", "MOVE");
                }
                else
                {
                    return ("Out of Bound");                    
                }
            }
            else
            {
                _rover.SetOrientation(instr[2]);
                _logFile.LogValues("Change orientation: " + _rover.GetOrientation(), "CHG ORIENT.");
            }
            return "SUCCES";
        }

        public void Show()
        {
            Console.Clear();
            _map.UpdateMap(_rover.GetPositionX(), _rover.GetPositionY(), _rover.GetOrientation());
            _logFile.LogValues("Update map with obj positions: (x, y, orientation) = (" + _rover.GetPositionX()+","+ _rover.GetPositionY()+","+_rover.GetOrientation()+")", "CHANGE ORT.");
            _map.PrintMap();
            _logFile.LogValues("PrintMap", "CHANGE ORT. ");

        }

        public void ExitProgram()
        {
           Console.WriteLine(".....Program Over.....");
         
        }

        public bool VerifyInstruction(int x, int y)
        {
            _logFile.LogValues("Verify instr.: (x, y) = (" + _rover.GetPositionX() + "," + _rover.GetPositionY() +")", "VERIFY");

            if (_rover.GetPositionX() + x < 0)
                return false;

            if (_rover.GetPositionX() + x >= _map.GetNoRows())
                return false;

            if (_rover.GetPositionY() + y < 0)
                return false;

            if (_rover.GetPositionY() + y >= _map.GetNoCols())
                return false;

            return true;
        }

        public void ShowError(string error)
        {
            _logFile.LogValues(error, "ERROR");

            Console.WriteLine(error);
        }

      
    }
}
