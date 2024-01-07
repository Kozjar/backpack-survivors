using Godot;
using System;

public partial class AttackBahaviour : Node
{
  public bool initialized = false;

  public virtual void InitializePosition(Vector2 position, Vector2? target = null)
  {
    initialized = true;
  }
}
