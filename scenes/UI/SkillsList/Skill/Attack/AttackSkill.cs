using Godot;
using System;

public partial class AttackSkill : GodotObject
{
  public SkillResource skillResource;

  public AttackSkill(SkillResource skillResource)
  {
    this.skillResource = skillResource;
  }
}
