using OpenTK;
using OpenTK.Graphics;

namespace OpenToolKit {
    public struct Vertex {

        public const int Size = (3 + 4) * 4;

        private readonly Vector3 position;
        private readonly Color4 colour;

        public Vertex(Vector3 position, Color4 colour) {
            this.position = position;
            this.colour = colour;
        }
    }
}
