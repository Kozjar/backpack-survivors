using Godot;
using System;

public partial class Artifact : Node2D
{
  [Signal] public delegate void ArtifactTakenEventHandler(ArtifactType type);
  [Export] public ArtifactType type = ArtifactType.Emma;

  public void OnPlayerDetect()
  {
    EmitSignal(SignalName.ArtifactTaken, (int)type);
  }
}
