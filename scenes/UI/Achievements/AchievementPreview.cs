using Godot;
using System;

public partial class AchievementPreview : PanelContainer
{
  [Export] public TextureRect iconNode;
  [Export] public Label NameNode { get; set; }
  [Export] public Label ConditionNode { get; set; }
  [Export] public Label RewardNode { get; set; }

  public void ShowAchievement(Achievement achievement)
  {
    iconNode.Texture = achievement.icon;
    NameNode.Text = achievement.name;
    ConditionNode.Text = achievement.condition;
    RewardNode.Text = achievement.reward;
    if (achievement.enabled)
    {
      iconNode.Material = null;
    }
  }
}
