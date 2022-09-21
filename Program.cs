// See https://aka.ms/new-console-template for more information
using Assigment.Controller;
using Assigment.Models;
using Assignment.Models;

Console.Write("LimitX = ");
int LimitX = Int32.Parse(Console.ReadLine());

Console.Write("LimitY = ");
int LimitY = Int32.Parse(Console.ReadLine());



Map map = new Map(LimitX, LimitY);
Log logFile = new Log("D:\\Assignment\\logFile.txt"); 
IProgramManager pm = new ProgramManager(map, logFile,2);

List<Position> positions = new List<Position>();

pm.StartProgram();

while (true)
{
    // positions.Add(pm.GetInstruction());
    if (pm.FollowUpInstruction(pm.GetInstruction()).Equals("SUCCES"))
        pm.Show();
    else
        pm.ShowError("Out Of Bound");
}

