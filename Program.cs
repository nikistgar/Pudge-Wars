using System;

namespace PudgeWars
{
    internal class Program
    {
        static void Main()
        {
            using Main window = new Main(500, 500, "Baza");
            window.Run();
        }
    }
}