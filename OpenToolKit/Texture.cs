using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace OpenToolKit {
	public class Texture {

		private int handle;

		public Texture(Bitmap image) {
			GL.GenTextures(1, out handle);
			Bind();

			System.Drawing.Imaging.BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, imageData.Width, imageData.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, imageData.Scan0);
			image.UnlockBits(imageData);

			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);

			GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
		}

		public void Bind() {
			GL.BindTexture(TextureTarget.Texture2D, handle);
		}

		public void Unbind() {
			GL.BindTexture(TextureTarget.Texture2D, 0);
		}
	}
}
