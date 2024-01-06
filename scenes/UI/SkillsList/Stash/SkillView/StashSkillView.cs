using Godot;
using System;

public partial class StashSkillView : SkillView
{
  [Export] Label description;
  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    base._Ready();
    description.Text = skillData.skillResource.Description;
  }
}
