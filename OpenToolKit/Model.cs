using OpenTK;

namespace OpenToolKit {
	public class Model {

		private Vertex[] vertices;
		private VertexArray vertexArray;

		private Vector3 position;
		private Quaternion rotation;

		public Vector3 Position { get { return position; } }
		public Quaternion Rotation { get { return rotation; } }

		public Model(Vertex[] vertices) {
			this.vertices = vertices;

			position = new Vector3(0, 0, 0);
			rotation = new Quaternion(0, 0, 0);
		}

		public void Initialise() {
			vertexArray = new VertexArray(new VertexBuffer(vertices));
		}

		public void Move(float dx, float dy, float dz) {
			position += new Vector3(dx, dy, dz);
		}

		public void SetPosition(float x, float y, float z) {
			position = new Vector3(x, y, z);
		}

		public void SetModelMatrix() {
			new MatrixUniform(4, Matrix4.CreateTranslation(position) * Matrix4.CreateFromQuaternion(rotation)).Set();
		}

		public void Draw() {
			SetModelMatrix();
			vertexArray.Bind();
			vertexArray.Draw();
			vertexArray.Unbind();
		}
	}
}