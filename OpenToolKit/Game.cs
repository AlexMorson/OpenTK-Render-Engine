using System;

using OpenTK;

namespace OpenToolKit {
	class Game : Window {

        private double framesElapsed = 0;
        private Model[] models;

        public Game() : base(400, 300, "OpenTK Render Engine") {}

        protected override void OnStart() {
            models = new Model[2];

            Vertex[] vertices1 = new Vertex[3];
			vertices1[0] = new Vertex(new Vector3(-1f, -1f, -1.5f), new Vector2(0f, 1f));
			vertices1[1] = new Vertex(new Vector3( 1f, -1f, -1.5f), new Vector2(1f, 1f));
			vertices1[2] = new Vertex(new Vector3(-1f,  1f, -1.5f), new Vector2(0f, 0f));
            
            Vertex[] vertices2 = new Vertex[3];
            vertices2[0] = new Vertex(new Vector3(-1f,  1f, -1.5f), new Vector2(0f, 0f));
            vertices2[1] = new Vertex(new Vector3( 1f,  1f, -1.5f), new Vector2(1f, 0f));
            vertices2[2] = new Vertex(new Vector3( 1f, -1f, -1.5f), new Vector2(1f, 1f));

            Texture texture = Loader.LoadTexture("res\\smiley.bmp");

            models[0] = new Model(vertices1, texture);
            models[1] = new Model(vertices2, texture);
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            framesElapsed += 0.05;

            models[0].Move((float)Math.Sin(framesElapsed) / 40, (float)Math.Cos(framesElapsed) / 40, 0);
        }

        protected override Model[] GetModels() {
            return models;
        }
    }
}
