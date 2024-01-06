using Godot;
using System;
using System.Collections.Generic;

public partial class SkillSelection : PanelContainer
{
  public delegate void SkillSelectedHandler(SkillAbstract skill);
  public event SkillSelectedHandler SkillSelectedEvent;

  [Export] PackedScene skillButtonAsset;
  [Export] Node container;

  public void ShowSkills(List<SkillAbstract> skills)
  {
    foreach (var skill in skills)
    {
      var skillButtonScene = skillButtonAsset.Instantiate<SkillButton>();
      container.AddChild(skillButtonScene);

      skillButtonScene.init(skill);
      skillButtonScene.Pressed += () => SkillSelectedEvent?.Invoke(skill);
    }
  }
}
