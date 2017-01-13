using OpenTK.Graphics.OpenGL;

namespace OpenToolKit {
    internal class VertexAttribute {

        private int location;
        private int size;
        private VertexAttribPointerType type;
        private bool normalise;
        private int stride;
        private int offset;

        public VertexAttribute(int location, int size, VertexAttribPointerType type, bool normalise, int stride, int offset) {
			this.location = location;
			this.size = size;
            this.type = type;
            this.normalise = normalise;
            this.stride = stride;
            this.offset = offset;
        }

        public void Set() {
            GL.EnableVertexAttribArray(location);
            GL.VertexAttribPointer(location, size, type, normalise, stride, offset);
        }

    }
}
