using Godot;
using System;
using System.Threading.Tasks;

public partial class ControlledShaderManager
{
	double timePassed = 0.0;
	Node2D node;
	string propertyName;
	double duration;

	public ControlledShaderManager(Node2D node, string propertyName, double duration, Shader shader)
	{
		if (shader != null)
		{
			ApplyShader(node, shader);
		}

		this.node = node;
		this.propertyName = propertyName;
		this.duration = duration;
	}

	public void Proccess(double delta)
	{
		timePassed += delta;
		var material = (ShaderMaterial)node.Material;
		material?.SetShaderParameter(propertyName, timePassed / duration);

		if (timePassed > duration) {
			node.Material = null;
		}
	}

	public void ApplyShader(Node2D node, Shader shader)
	{
		var material = new ShaderMaterial { Shader = shader };

		node.Material = material;
	}
}
