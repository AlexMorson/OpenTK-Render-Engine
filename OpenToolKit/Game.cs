using System;

using OpenTK;
using OpenTK.Graphics;

namespace OpenToolKit {
	class Game : Window {

        private double framesElapsed = 0;
        private Model[] models;

        public Game() : base(400, 300, "OpenTK Render Engine") {}

        protected override void OnStart() {
            models = new Model[2];

            Vertex[] vertices1 = new Vertex[3];
			vertices1[0] = new Vertex(new Vector3(-2.6f, -0.4f, -1.5f), Color4.Orchid);
			vertices1[1] = new Vertex(new Vector3(0.4f, 0.5f, -0.8f), Color4.Goldenrod);
			vertices1[2] = new Vertex(new Vector3(0.5f, -1.2f, -1.5f), Color4.Firebrick);
            
			Vertex[] vertices2 = new Vertex[3];
			vertices2[0] = new Vertex(new Vector3(-0.4f, -0.2f, -0.3f), Color4.Blue);
			vertices2[1] = new Vertex(new Vector3(-3, 3, -5f), Color4.Red);
			vertices2[2] = new Vertex(new Vector3(1.2f, -0.6f, -1.2f), Color4.Black);

            models[0] = new Model(vertices1);
            models[1] = new Model(vertices2);
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
