using System;

using OpenTK.Graphics.OpenGL;

namespace OpenToolKit {
	internal class ShaderProgram {

		private int handle;

		public ShaderProgram(params Shader[] shaders) {
			this.handle = GL.CreateProgram();

			foreach (var shader in shaders) {
				GL.AttachShader(this.handle, shader.handle);
			}

			GL.LinkProgram(this.handle);

			foreach (var shader in shaders) {
				GL.DetachShader(this.handle, shader.handle);
			}

			// Error output
			Console.WriteLine(GL.GetProgramInfoLog(handle));
		}

		public int GetAttributeLocation(string name) {
			return GL.GetAttribLocation(handle, name);
		}

		public int GetUniformLocation(string name) {
			return GL.GetUniformLocation(handle, name);
		}

		public void Use() {
			GL.UseProgram(handle);
		}

		public void StopUsing() {
			GL.UseProgram(0);
		}
	}
}
