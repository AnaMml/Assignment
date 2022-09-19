// See https://aka.ms/new-console-template for more information
using Assigment.Controller;
using Assigment.Models;

Console.Write("LimitX = ");
int LimitX = Int32.Parse(Console.ReadLine());

Console.Write("LimitY = ");
int LimitY = Int32.Parse(Console.ReadLine());

int[] instr = new int[3];
IMap map = new Map(LimitX, LimitY);
ILog logFile = new Log("D:\\Assignment\\logFile.txt"); 
IProgramManager pm = new ProgramManager(map, logFile);
pm.StartProgram();



while (true)
{
    instr = pm.GetInstruction();
    if (instr.Sum() > 0)
    {
        if (pm.FollowUpInstruction(instr).Equals("SUCCES"))
            pm.Show();
        else
            pm.ShowError("Out of Bound.");
    }
    else
        pm.ExitProgram();
}

