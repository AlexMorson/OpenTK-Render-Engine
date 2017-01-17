using OpenTK;
using OpenTK.Graphics;

namespace OpenToolKit {
    public struct Vertex {

        public const int Size = (3 + 2) * 4;

        private readonly Vector3 position;
        private readonly Vector2 uvCoord;

        public Vertex(Vector3 position, Vector2 uvCoord) {
            this.position = position;
            this.uvCoord = uvCoord;
        }
    }
}
