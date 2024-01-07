using Godot;
using System;

public partial class StaticBehaviour : AttackBahaviour
{
  [Export] Node2D attack;
  [Export] public double duration = 0.4f;
  [Export] float initRange = 30f;

  public override void _Ready()
  {
    SceduleDestroy();
    // shaderManager = new ControlledShaderManager(shape, "progress", duration, null);
  }

  private async void SceduleDestroy()
  {
    await ToSignal(GetTree().CreateTimer(duration, false), "timeout");

    attack.QueueFree();
  }

  override public void InitializePosition(Vector2 position, Vector2? target = null)
  {
    base.InitializePosition(position, target);
    if (target != null)
    {
      attack.Position -= target.Value * initRange;
    }
    else
    {
      attack.Position += (Vector2.One * (float)GD.RandRange(0d, initRange)).Rotated((float)GD.RandRange(-MathF.PI, MathF.PI));
    }
  }
}
