using System;
using static PudgeWars.Window;

namespace PudgeWars
{
    internal class main 
    {
        static void Main()
        {
            Window window = new Window(500, 500, "Hello world");
            window.Run();
        }
    }
}