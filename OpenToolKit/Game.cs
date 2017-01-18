using System;

using OpenTK;

namespace OpenToolKit {
	class Game : Window {

		private double framesElapsed = 0;
		private Model model;
		private Mesh[] meshes;

		public Game() : base(400, 300, "OpenTK Render Engine") {}

		protected override void OnStart() {
			Vertex[] vertices1 = new Vertex[3];
			vertices1[0] = new Vertex(new Vector3(-1f, -1f, 0f), new Vector2(0f, 1f));
			vertices1[1] = new Vertex(new Vector3( 1f, -1f, 0f), new Vector2(1f, 1f));
			vertices1[2] = new Vertex(new Vector3(-1f,  1f, 0f), new Vector2(0f, 0f));
			
			Vertex[] vertices2 = new Vertex[3];
			vertices2[0] = new Vertex(new Vector3(-1f,  1f, 0f), new Vector2(0f, 0f));
			vertices2[1] = new Vertex(new Vector3( 1f,  1f, 0f), new Vector2(1f, 0f));
			vertices2[2] = new Vertex(new Vector3( 1f, -1f, 0f), new Vector2(1f, 1f));
			
			Texture texture = Loader.LoadTexture("res\\smiley.bmp");
			
			meshes = new Mesh[2];
			meshes[0] = new Mesh(vertices1, texture);
			meshes[1] = new Mesh(vertices2, texture);
			
			model = new Model(meshes);
			model.Translate(0f, 0f, -1.5f);
		}

		protected override void OnUpdateFrame(FrameEventArgs e) {
			framesElapsed += 0.05;

			meshes[0].Translate((float)Math.Sin(framesElapsed) / 40, (float)Math.Cos(framesElapsed) / 40, 0);
			meshes[1].Rotate(0.02f, 0, 0.01f);
			//model.Rotate(0, 0, 0.02f);
		}

		protected override Model[] GetModels() {
			return new Model[] { model };
		}
	}
}
