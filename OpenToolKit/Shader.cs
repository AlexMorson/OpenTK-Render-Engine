using OpenTK.Graphics.OpenGL;

namespace OpenToolKit {
    internal class Shader {

        private int _handle;
        public int handle { get { return _handle; } }

        public Shader(ShaderType shaderType, string code) {
            this._handle = GL.CreateShader(shaderType);

            GL.ShaderSource(this._handle, code);
            GL.CompileShader(this._handle);
        }

    }
}