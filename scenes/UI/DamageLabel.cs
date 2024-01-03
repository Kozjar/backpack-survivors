using Godot;
using System;

public partial class DamageLabel : Label
{
  public void Initialize(float damage, Sprite2D character, Color color)
  {
    Text = ((int)damage).ToString();
    AddThemeColorOverride("font_color", color);

    Position = CalcPosition(character);
    Fade();
  }

  private void Fade()
  {
    var tween = GetTree().CreateTween();
    tween.Parallel().TweenProperty(this, "modulate", new Color(Modulate.R, Modulate.G, Modulate.B, 0), 0.8f);
    tween.Parallel().TweenProperty(this, "position", new Vector2(Position.X, Position.Y - 10f), 0.8f);
    // tween.TweenCallback(Callable.From(QueueFree));
  }

  private Vector2 CalcPosition(Sprite2D character)
  {
    var size = character.Texture.GetSize();
    SetSize(new Vector2(size.X, Size.Y));

    return new Vector2(character.GlobalPosition.X - size.X / 2, character.GlobalPosition.Y - size.Y / 2);
  }
}
