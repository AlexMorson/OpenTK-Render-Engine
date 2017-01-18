using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenToolKit {
	public class Window : GameWindow {
		
		private ShaderProgram shaderProgram;
		private MatrixUniform projectionMatrix;

		public Window(int width=800, int height=600, string title="Title!") : base(width, height, GraphicsMode.Default, title, GameWindowFlags.Default, DisplayDevice.Default, 3, 3, GraphicsContextFlags.ForwardCompatible) {
			Console.WriteLine("OpenGL Version: {0}", GL.GetString(StringName.Version));
		}


		protected override void OnLoad(EventArgs e) {
			GL.Enable(EnableCap.DepthTest);

			// Load shaders
			Shader vertexShader = new Shader(ShaderType.VertexShader,
@"#version 430

layout (location = 0) in vec3 vPosition;
layout (location = 1) in vec2 vUVCoord;

layout (location = 2) uniform mat4 projectionMatrix;
//layout (location = 3) uniform mat4 viewMatrix;
layout (location = 4) uniform mat4 modelMatrix;
layout (location = 5) uniform mat4 meshMatrix;

out vec2 fUVCoord;

void main() {
	gl_Position = projectionMatrix * modelMatrix * meshMatrix * vec4(vPosition, 1.0);
	fUVCoord = vUVCoord;
}"
				);
			Shader fragmentShader = new Shader(ShaderType.FragmentShader,
@"#version 430

in vec2 fUVCoord;

layout (binding = 0) uniform sampler2D sampler;

out vec4 colour;

void main() {
	colour = texture(sampler, fUVCoord);
}"
				);

			shaderProgram = new ShaderProgram(vertexShader, fragmentShader);

			// Load projection matrix
			projectionMatrix = new MatrixUniform(2); // projectionMatrix
			projectionMatrix.Matrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver2, 16f / 9f, 0.1f, 100f);

			// Texture locations
			GL.Uniform1(0, 0); // Diffuse texture at location 0, with texture unit 0

			// User implemented startup
			OnStart();
		}

		protected virtual void OnStart() {

		}

		protected override void OnResize(EventArgs e) {
			GL.Viewport(0, 0, Width, Height);
		}

		protected virtual Model[] GetModels() {
			return new Model[0];
		}

		protected override void OnRenderFrame(FrameEventArgs e) {
			GL.ClearColor(Color4.DodgerBlue);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			shaderProgram.Use();
			
			projectionMatrix.Set();
			
			foreach (var model in GetModels()) {
				model.Draw();
			}
			
			shaderProgram.StopUsing();
			
			SwapBuffers();
		}
	}
}