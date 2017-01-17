using System.Drawing;

namespace OpenToolKit {
	public static class Loader {
		/*public static Model LoadModel(string filepath) {

		}*/

        public static Texture LoadTexture(string filename) {
            return new Texture(new Bitmap(filename));
        }
	}
}
