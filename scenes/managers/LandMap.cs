using Godot;
using System;

public partial class LandMap : TileMap
{
	int width = 1920 / 32 + 2;
	int height = 1080 / 32 + 2;
	[Export]
	public Sprite2D player;

	FastNoiseLite modernityNoise = new FastNoiseLite();
	FastNoiseLite intensityNoise = new FastNoiseLite();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetupNoise(modernityNoise);
		SetupNoise(intensityNoise);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Clear();
		GenerateChunk(player.GlobalPosition);
	}

	private void SetupNoise(FastNoiseLite noise)
	{
		noise.Seed = (int)GD.Randi();
		noise.Frequency = 0.2f;
		noise.CellularDistanceFunction = FastNoiseLite.CellularDistanceFunctionEnum.Hybrid;
		noise.DomainWarpAmplitude = 100;
	}

	private void GenerateChunk(Vector2 position)
	{
		var localPos = LocalToMap(position);

		for (int i = 0; i < width; i++)
		{
			for (int j = 0; j < height; j++)
			{
				var tilePos = new Vector2I(localPos.X - (int)(width / 2) + i, localPos.Y - (int)(height / 2) + j);

				GenerateCell(tilePos);
			}
		}
	}

	private void GenerateCell(Vector2I tilePos)
	{
		var modernity = modernityNoise.GetNoise2D(tilePos.X, tilePos.Y);
		var intensity = intensityNoise.GetNoise2D(tilePos.X, tilePos.Y);

		var tilesetCoord = new Vector2I((int)Math.Round((intensity + 1) * 5 / 2), (int)Math.Round((modernity + 1) * 7 / 2));

		SetCell(0, tilePos, 3, tilesetCoord);
	}
}
