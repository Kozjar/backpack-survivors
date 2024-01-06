using Godot;
using System;

public partial class SkillData : GodotObject
{
  public SkillResource skillResource;

  public SkillData(SkillResource skillResource)
  {
    this.skillResource = skillResource;
  }

  public virtual void Reset()
  {

  }
}
