using Godot;
using System;

public partial class Wall : RigidBody2D
{
  [Export] CollisionShape2D collisionShape;
  [Export] Sprite2D sprite;

  public void SetSize(Vector2 size)
  {
    ((RectangleShape2D)collisionShape.Shape).Size = size;
    sprite.Scale = new Vector2(size.X / sprite.Texture.GetWidth(), size.Y / sprite.Texture.GetHeight());
  }
}
