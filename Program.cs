using System;

namespace PudgeWars
{
    internal class Program
    {
        static void Main()
        {
            using Main window = new Main(1920, 720, "Baza");
            window.Run();
        }
    }
}