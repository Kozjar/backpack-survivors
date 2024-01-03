using Godot;
using System;

public partial class SkillDragData : GodotObject
{
  public SkillResource skillResource { get; set; }
  public ISkillContainer previousParent { get; set; }

  public SkillDragData(SkillResource skillResource, ISkillContainer previousParent)
  {
    this.skillResource = skillResource;
    this.previousParent = previousParent;
  }
}
