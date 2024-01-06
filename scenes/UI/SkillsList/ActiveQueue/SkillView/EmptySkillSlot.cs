using Godot;
using System;

public partial class EmptySkillSlot : Control
{
  [Export] public SkillDropPreview dropPreview;

  public override void _Ready()
  {
    SkillListGlobal.instance.DragStarted += OnDragStarted;
    SkillListGlobal.instance.DragEnded += dropPreview.HideDropPreview;
  }

  void OnDragStarted(SkillData skillData)
  {
    if (skillData is Trigger)
    {
      dropPreview.ShowDropPreview();
    }
  }

  public override void _ExitTree()
  {
    base._ExitTree();
    SkillListGlobal.instance.DragStarted -= OnDragStarted;
    SkillListGlobal.instance.DragEnded -= dropPreview.HideDropPreview;
  }
}
