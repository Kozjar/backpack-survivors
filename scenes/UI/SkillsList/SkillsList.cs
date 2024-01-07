using Godot;
using System;

public partial class SkillsList : PanelContainer
{
  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("openBackpack"))
    {
      SkillListGlobal.instance.ToggleGameplay();
      Visible = !Visible;
    }
  }

  public void Open()
  {
    Visible = true;
  }

  public void OnConfirm()
  {
    Visible = false;
    SkillListGlobal.instance.ResumeGameplay();
  }
}
