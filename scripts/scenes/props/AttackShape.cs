using Godot;
using System;

public partial class AttackShape : Polygon2D
{
  [Export] public CollisionPolygon2D collisionPolygon2D;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    UpdatePolygon();
  }

  void UpdatePolygon()
  {
    collisionPolygon2D.Polygon = Polygon;
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
  }
}
