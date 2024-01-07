using Godot;
using System;

public partial class ArtifactMark : Control
{
  [Export] Node2D artifactNode;
  float margin = 35;

  public override void _Process(double delta)
  {
    base._Process(delta);
    var relativePosition = artifactNode.GlobalPosition - SkillListGlobal.instance.player.GlobalPosition + (SkillListGlobal.screenSize / 2);
    Visible = !IsInsideScreen(relativePosition);
    Position = BoundPositionToTheCamera(relativePosition);
  }

  bool IsInsideScreen(Vector2 position)
  {
    var size = SkillListGlobal.screenSize;
    return position.X > 0 && position.X < size.X && position.Y > 0 && position.Y < size.Y;
  }

  Vector2 BoundPositionToTheCamera(Vector2 position)
  {
    var size = SkillListGlobal.screenSize;
    var x = position.X < margin ? margin : position.X > size.X - margin ? size.X - margin : position.X;
    var y = position.Y < margin ? margin : position.Y > size.Y - margin ? size.Y - margin : position.Y;
    return new Vector2(x, y);
  }
}
