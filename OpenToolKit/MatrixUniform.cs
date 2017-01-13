using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenToolKit {
	internal class MatrixUniform {

		private int location;
		private Matrix4 matrix;

		public Matrix4 Matrix { get { return matrix; } set { matrix = value; } }

		public MatrixUniform(int location) {
			this.location = location;
		}

		public MatrixUniform(int location, Matrix4 matrix) : this(location) {
			this.matrix = matrix;
		}

		public void Set() {
			GL.UniformMatrix4(location, false, ref matrix);
		}
	}
}
