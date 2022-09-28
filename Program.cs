// See https://aka.ms/new-console-template for more information
using Assigment.Controller;
using Assigment.Models;
using Assignment.Models;

Console.Write("LimitX = ");
int LimitX = Int32.Parse(Console.ReadLine());

Console.Write("LimitY = ");
int LimitY = Int32.Parse(Console.ReadLine());

Map map = new Map(LimitX, LimitY);

string filePath = Directory.GetCurrentDirectory();
filePath = Path.Combine(filePath, "logFile.txt");
Log logFile = new Log(filePath); 

IProgramManager pm = new ProgramManager(map, logFile);

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

