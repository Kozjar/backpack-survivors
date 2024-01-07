using Godot;
using System;

public partial class SkillResource : SkillBaseResource
{
  [Export] public PackedScene inventoryScene;
  [Export] public PackedScene dragScene = ResourceLoader.Load<PackedScene>("res://scenes/UI/SkillsList/SkillView/SkillDragPreview.tscn");

  public virtual SkillData CreateInstance()
  {
    return new SkillData(this);
  }
}
