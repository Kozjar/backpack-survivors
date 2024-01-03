using Godot;
using System;

public partial class Trigger : GodotObject
{
  public SkillResource skillResource;
  public AttackSkill Attack { get; set; }

  public Trigger(SkillResource skillResource)
  {
    this.skillResource = skillResource;
  }
}
