using Godot;
using System;

public partial class SceneController : Node
{
  public void Pause() {
    GetTree().Paused = true;
  }
}
