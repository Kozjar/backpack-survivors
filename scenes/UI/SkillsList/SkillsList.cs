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
}
