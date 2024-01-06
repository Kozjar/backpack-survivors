using Godot;
using System;

public partial class StaticBehaviour : Node
{
  [Export] Node2D attack;
  [Export] public double duration = 0.4f;

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
}
