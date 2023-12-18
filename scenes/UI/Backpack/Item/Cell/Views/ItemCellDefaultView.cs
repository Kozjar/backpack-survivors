using Godot;
using System;

public partial class ItemCellDefaultView : Control
{
  [Export] public ItemCellConfig cell;
  public Vector2 Center => Constants.cellSize * Vector2.One / 2;
  public Vector2 GlobalCenter => GlobalPosition;

  public override void _Ready()
  {
  }

  public override void _Process(double delta)
  {
    // GD.Print(Rotation);
  }
}
