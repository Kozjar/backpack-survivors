using Godot;
using System;

public partial class XPBar : ProgressBar
{
  [Export] public Label label;
  [Export] public XPConsumer xpManager;

  public override void _Process(double delta)
  {
    MaxValue = xpManager.xpRequired;
    ChangeLevelProgress(xpManager.currentXp);
  }

  public void ChangeLevelProgress(float xp)
  {
    Value = xp;
    label.Text = $"{Value} / {MaxValue} ({Math.Round(Value / MaxValue * 100)}%)";
  }

  public void OnLevelUp(int level, float maxXp)
  {
    MaxValue = maxXp;
  }
}
