using Godot;
using System;

public partial class AchievementView : Control
{
  public Achievement achievement;
  [Export] TextureRect iconNode;

  public override void _Ready()
  {
    base._Ready();
  }

  public void Init(Achievement achievement)
  {
    this.achievement = achievement;
    iconNode.Texture = achievement.icon;
    if (achievement.enabled)
    {
      iconNode.Material = null;
    }
  }
}
