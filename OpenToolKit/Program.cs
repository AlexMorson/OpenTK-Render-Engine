using OpenTK;
using OpenTK.Graphics;
using System;

namespace OpenToolKit {
	class Program {
		static void Main(string[] args) {

			Vertex[] vertices = new Vertex[3];
			vertices[0] = new Vertex(new Vector3(-2.6f, -0.4f, -1.5f), Color4.Orchid);
			vertices[1] = new Vertex(new Vector3(0.4f, 0.5f, -0.8f), Color4.Goldenrod);
			vertices[2] = new Vertex(new Vector3(0.5f, -1.2f, -1.5f), Color4.Firebrick);

			Model[] models = new Model[2];
			models[0] = new Model(vertices);

			Vertex[] vertices2 = new Vertex[3];
			vertices2[0] = new Vertex(new Vector3(-0.4f, -0.2f, -0.3f), Color4.Blue);
			vertices2[1] = new Vertex(new Vector3(-3, 3, -5f), Color4.Red);
			vertices2[2] = new Vertex(new Vector3(1.2f, -0.6f, -1.2f), Color4.Black);
			
			models[1] = new Model(vertices2);

			new Window(models).Run(60); // Maybe change to Game object being passed that has a GetModels and Update.
		}
	}
}
