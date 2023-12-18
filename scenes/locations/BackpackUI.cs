using Godot;
using System;

public partial class BackpackUI : Control
{
  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("openBackpack"))
    {
      Visible = !Visible;
    }
  }
}
