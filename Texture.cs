using OpenTK.Graphics.OpenGL4;
using StbImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PudgeWars
{
    internal class Texture
    {
        private ImageResult image;
        private int texture;
        public Texture(string path)
        {
            try
            {
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                texture = GL.GenTexture();
                Bind();

            }catch(BadImageFormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void Bind()
        {
            GL.BindTexture(TextureTarget.Texture2D, texture);
        }

        public ImageResult GetImage()
        {
            return image;
        }
    }
}
