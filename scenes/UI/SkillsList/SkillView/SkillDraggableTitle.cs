using Godot;
using System;

public partial class SkillDraggableTitle : PanelContainer
{
  public ISkillContainer parent;
  public SkillData skillData;

  public void Init(ISkillContainer parent, SkillData skillData)
  {
    this.parent = parent;
    this.skillData = skillData;
  }

  public override Variant _GetDragData(Vector2 atPosition)
  {
    var preview = skillData.skillResource.dragScene.Instantiate<SkillDragPreview>();
    preview.Init(skillData);

    SetDragPreview(preview);

    return new SkillDragData(skillData, parent);
  }
}
