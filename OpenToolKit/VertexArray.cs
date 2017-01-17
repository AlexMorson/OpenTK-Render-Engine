using OpenTK.Graphics.OpenGL;
using System;

namespace OpenToolKit {
    internal class VertexArray {

        private int handle;

		private int vertexCount;

        public VertexArray(VertexBuffer buffer, params VertexAttribute[] attributes) {
			this.vertexCount = buffer.VertexCount;

			GL.GenVertexArrays(1, out handle);
			
            Bind();

            buffer.Bind();

			buffer.BufferData();

			new VertexAttribute(0, 3, VertexAttribPointerType.Float, false, Vertex.Size, 0).Set();    // vPosition
			new VertexAttribute(1, 2, VertexAttribPointerType.Float, false, Vertex.Size, 3 * 4).Set(); // vUVCoord

			buffer.Unbind();

            Unbind();
        }

        public void Bind() {
            GL.BindVertexArray(handle);
        }

        public void Unbind() {
            GL.BindVertexArray(0);
		}

		public void Draw() {
			GL.DrawArrays(PrimitiveType.Triangles, 0, vertexCount);
		}
	}
}