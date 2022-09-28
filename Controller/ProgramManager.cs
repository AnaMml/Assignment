using Assigment.Models;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Controller

{
    public class ProgramManager : IProgramManager
    {
        private readonly Map _map;
        private readonly Rover _rover;
        private readonly Log _logFile;
        private readonly IPrinterCreator _printerFactory;

        public ProgramManager(Map map, Log logFile)
        {
            _map = map;
            _rover = new Rover(map.GetNoRows(),map.GetNoCols());
            _logFile = logFile;

            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                _printerFactory = new PrinterTxtCreator();
            else
                _printerFactory = new PrinterConsoleCreator();
        }

        public void StartProgram()
        {
            Show();
            _logFile.LogValues("Program start", "START");
        }

        public Position GetInstruction()
        {
            ConsoleKey ch = Console.ReadKey().Key;
            _logFile.LogValues(ch.ToString(), "INSTR.");
            switch (ch)
            {                
                case ConsoleKey.UpArrow:
                    return new Position(-1, 0, 24 ); // {x, y, orientation}
                case ConsoleKey.DownArrow:
                    return new Position ( 1, 0, 25 );
                case ConsoleKey.LeftArrow:
                    return new Position ( 0, -1, 27 );                  
                case ConsoleKey.RightArrow:
                    return new Position ( 0, 1, 26 );                        
                default:
                    return new Position(0,0,0);
            }
        }


        public string FollowUpInstruction(Position newPosition)
        {
            _map.ReloadMap();
            if (_rover.GetOrientation() == newPosition.orientation)
            {
                if(VerifyInstruction(newPosition.positionX, newPosition.positionY) == true)
                {
                    _rover.Move(newPosition.positionX, newPosition.positionY);
                    _logFile.LogValues("New values: map(x,y) = map(" + _rover.GetPositionX() + "," + _rover.GetPositionY() + ")", "MOVE");
                }
                else
                {
                    return ("Out of Bound");                    
                }
            }
            else
            {
                _rover.SetOrientation(newPosition.orientation);
                _logFile.LogValues("Change orientation: " + _rover.GetOrientation(), "CHG ORIENT.");
            }
            return "SUCCES";
        }

        public void Show()
        {
            //Console.Clear();
            _map.UpdateMap(_rover.GetPositionX(), _rover.GetPositionY(), _rover.GetOrientation());
            _logFile.LogValues("Update map with obj positions: (x, y, orientation) = (" + _rover.GetPositionX()+","+ _rover.GetPositionY()+","+_rover.GetOrientation()+")", "CHANGE ORT.");
            _printerFactory.CreatePrinter().Print(_map);  
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
