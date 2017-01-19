using OpenTK;

namespace OpenToolKit {
	public class Mesh : MovableObject {
		
		private Texture texture;
		private VertexArray vertexArray;

		public Mesh(Vertex[] vertices, Texture texture) {
			this.texture = texture;
			this.vertexArray = new VertexArray(new VertexBuffer(vertices));
		}

		public void SetMeshMatrix() {
			new MatrixUniform(5, GetTransformationMatrix()).Set();
		}

		public void Draw() {
			SetMeshMatrix();
			texture.Bind();

			vertexArray.Bind();
			vertexArray.Draw();
			vertexArray.Unbind();

			texture.Unbind();
		}
	}
}