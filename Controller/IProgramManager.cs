using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment.Controller
{
    public interface IProgramManager
    {
        void StartProgram();
        Position GetInstruction();
        bool VerifyInstruction(int x, int y);
        string FollowUpInstruction(Position instructionId);
        void Show();
        void ExitProgram();
        void ShowError(string errorName);

    }
}
