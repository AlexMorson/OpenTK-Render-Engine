using OpenTK;

namespace OpenToolKit {
	public class MovableObject {

		private Vector3 position;
		private Vector3 rotation;

		public Vector3 Position { get { return position; } }
		public Vector3 Rotation { get { return rotation; } }

		public MovableObject() {
			position = new Vector3(0, 0, 0);
			rotation = new Vector3(0, 0, 0);
		}

		public void Translate(float dx, float dy, float dz) {
			position += new Vector3(dx, dy, dz);
		}

		public void SetPosition(float x, float y, float z) {
			position = new Vector3(x, y, z);
		}

		public void Rotate(float dPitch, float dYaw, float dRoll) {
			rotation += new Vector3(dPitch, dYaw, dRoll);
		}

		public void SetRotation(float pitch, float yaw, float roll) {
			rotation = new Vector3(pitch, yaw, roll);
		}

		public Matrix4 GetTransformationMatrix() {
			return Matrix4.CreateFromQuaternion(new Quaternion(rotation)) * Matrix4.CreateTranslation(position);
		}
	}
}
