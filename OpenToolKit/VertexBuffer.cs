using System;

using OpenTK.Graphics.OpenGL;

namespace OpenToolKit {
	internal class VertexBuffer {

		private int handle;

		private int vertexSize;
		private int vertexCount;
		private Vertex[] vertices;

		public int VertexCount { get { return vertexCount; } }

		public VertexBuffer() {
			GL.GenBuffers(1, out this.handle);

			this.vertexSize = Vertex.Size;
			this.vertexCount = 0;
			this.vertices = new Vertex[4];
		}

		public VertexBuffer(Vertex[] vertices) : this() {
			AddVertices(vertices);
		}

		public void AddVertex(Vertex vertex) {
			if (vertexCount == vertices.Length) {
				Array.Resize(ref vertices, 2 * vertices.Length);
			}
			vertices[vertexCount] = vertex;
			vertexCount++;
		}

		public void AddVertices(Vertex[] vertices) {
			foreach (var vertex in vertices) {
				AddVertex(vertex);
			}
		}

		public void Bind() {
			GL.BindBuffer(BufferTarget.ArrayBuffer, handle);
		}

		public void Unbind() {
			GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
		}

		public void BufferData() {
			GL.BufferData(BufferTarget.ArrayBuffer, vertexSize * vertexCount, vertices, BufferUsageHint.StaticDraw);
		}
	}
}