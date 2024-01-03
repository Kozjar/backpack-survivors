using Godot;
using System;

public partial class SkillDraggableTitle : PanelContainer
{
  public ISkillContainer parent;
  public SkillResource skillResource;

  public void Init(ISkillContainer parent, SkillResource skillResource)
  {
    this.parent = parent;
    this.skillResource = skillResource;
  }

  public override Variant _GetDragData(Vector2 atPosition)
  {
    var preview = skillResource.dragScene.Instantiate<SkillDragPreview>();
    preview.Init(skillResource);

    SetDragPreview(preview);

    return new SkillDragData(skillResource, parent);
  }
}
