using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Achievements : Control
{
  [Export] AchievementPreview achievementPreview;
  [Export] Node achievementsInstancesContainer;
  [Export] Node achievementContainer;
  [Export] PackedScene achievementScene;

  List<Achievement> achievements => achievementsInstancesContainer.GetChildren().OfType<Achievement>().ToList();

  public override void _Ready()
  {
    base._Ready();
    achievements.ForEach(achievement =>
    {
      var achievementView = achievementScene.Instantiate<AchievementView>();
      achievementView.Init(achievement);
      achievementView.MouseEntered += () => achievementPreview.ShowAchievement(achievement);
      achievementContainer.AddChild(achievementView);
    });
  }

  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("openAchievements"))
    {
      SkillListGlobal.instance.ToggleGameplay();
      Visible = !Visible;
    }
  }
}
