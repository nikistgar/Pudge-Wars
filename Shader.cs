using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Reflection.Metadata;

namespace PudgeWars
{
    internal class Shader
    {
        private int shader;
        public Shader(string path, ShaderType type)
        {
            shader = GL.CreateShader(type);
            GL.ShaderSource(shader, File.ReadAllText("..\\..\\..\\glsl\\" + path));
            GL.CompileShader(shader);
        }

        ~Shader()
        {
            GL.DeleteShader(shader);
        }

        public int GetShader()
        {
            return shader;
        }
        public void GetInformation()
        {
            Console.WriteLine(GL.GetShaderInfoLog(shader));
        }
    }
}
