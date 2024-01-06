using Godot;
using System;

public partial class SkillDropPreview : PanelContainer
{
  [Signal] public delegate void skillDroppedEventHandler(SkillDragData dragData);
  [Export] public Control childComponents;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    SkillListGlobal.instance.DragEnded += HideDropPreview;
  }

  public override void _ExitTree()
  {
    base._ExitTree();
    SkillListGlobal.instance.DragEnded -= HideDropPreview;
  }

  public override bool _CanDropData(Vector2 atPosition, Variant data)
  {
    return true;
  }

  public override void _DropData(Vector2 atPosition, Variant _data)
  {
    var data = (SkillDragData)_data;

    data.previousParent.RemoveSkill(data.skillData);
    EmitSignal(SignalName.skillDropped, data);
  }

  public void ShowDropPreview()
  {
    childComponents.Visible = false;
    Visible = true;
  }

  public void HideDropPreview()
  {
    childComponents.Visible = true;
    Visible = false;
  }
}
