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
        int[] GetInstruction();
        bool VerifyInstruction(int x, int y);
        string FollowUpInstruction(int[] instructionId);
        void Show();
        void ExitProgram();
        void ShowError(string errorName);

    }
}
