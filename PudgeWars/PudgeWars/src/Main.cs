using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLFW;

namespace PudgeWars.src
{
    internal class Test
    {
        static void Main()
        {
            using (var window = new NativeWindow(800, 600, "MyWindowTitle"))
            {
                // Main application loop
                while (!window.IsClosing)
                {
                    Console.WriteLine("Hello pidaras");
                    // OpenGL rendering
                    // Implement any timing for flow control, etc (see Glfw.GetTime())

                    // Swap the front/back buffers
                    window.SwapBuffers();

                    // Poll native operating system events (must be called or OS will think application is hanging)
                    Glfw.PollEvents();
                }
            }
        }
    }
}
