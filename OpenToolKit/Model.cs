using OpenTK;

namespace OpenToolKit {
	public class Model : MovableObject {

		private Mesh[] meshes;

		public Model(params Mesh[] meshes) {
			this.meshes = meshes;
		}

		public void SetModelMatrix() {
			new MatrixUniform(4, GetTransformationMatrix()).Set();
		}

		public void Draw() {
			SetModelMatrix();
			foreach (var mesh in meshes) {
				mesh.Draw();
			}
		}
	}
}
