using System;
using System.Linq;
using Godot;

public partial class Player : CharacterBody2D
{
  [Export] public StatsComponent statsComponent;

  public override void _UnhandledInput(InputEvent @event)
  {
  }
}
