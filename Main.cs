using System;

using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Reflection.Metadata;


namespace PudgeWars
{
    class Main : GameWindow
    {

        int shaderProgram,vao;
        public Main(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings()
        {
            Title = title,
            Size = new Vector2i(width, height),
            WindowBorder = WindowBorder.Resizable,
            StartVisible = false,
            StartFocused = true,
            WindowState = WindowState.Normal,
            API = ContextAPI.OpenGL,
            Profile = ContextProfile.Core,
            APIVersion = new Version(3, 3),
        })
        {
            CenterWindow();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);

            base.OnResize(e);
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            float[] vertices = {
                -0.5f, -0.5f, 0.0f,
                 0.5f, -0.5f, 0.0f,
                 0.0f,  0.5f, 0.0f
            };

            int vertexShader;
            vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, File.ReadAllText("..\\..\\..\\glsl\\test.vert"));
            GL.CompileShader(vertexShader);
            Console.WriteLine(GL.GetShaderInfoLog(vertexShader));

            int fragmentShader;
            fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, File.ReadAllText("..\\..\\..\\glsl\\test.frag"));
            GL.CompileShader(fragmentShader);
            Console.WriteLine(GL.GetShaderInfoLog(fragmentShader));

            shaderProgram = GL.CreateProgram();
            GL.AttachShader(shaderProgram, vertexShader);
            GL.AttachShader(shaderProgram, fragmentShader);
            GL.LinkProgram(shaderProgram);

            GL.GetProgram(shaderProgram, GetProgramParameterName.LinkStatus, out int success);
            if(success == 0)
            {
                string infoLog = GL.GetProgramInfoLog(shaderProgram);
                Console.WriteLine(infoLog);
            }

            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);

            int vbo;
            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, sizeof(float) * vertices.Length, vertices, BufferUsageHint.StaticDraw);

            //VAO
            GL.UseProgram(shaderProgram);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            IsVisible = true;
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.ClearColor(1.0f,0.5f,0.45f,1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.BindVertexArray(vao);
            int uniformLocale = GL.GetUniformLocation(shaderProgram, "sinColor");
            Vector3 sinVector = new Vector3(0.24f,0.5f,0.0f);
            GL.Uniform3(uniformLocale, sinVector);
            GL.UseProgram(shaderProgram);
            GL.DrawArrays(PrimitiveType.Triangles,0,3);
            SwapBuffers();
        }
    }
}
