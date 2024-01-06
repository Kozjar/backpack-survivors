using Godot;
using System;

public partial class SkillDragData : GodotObject
{
  public SkillData skillData { get; set; }
  public ISkillContainer previousParent { get; set; }

  public SkillDragData(SkillData skillData, ISkillContainer previousParent = null)
  {
    this.skillData = skillData;
    this.previousParent = previousParent;
  }
}
