using Godot;
using System;

public partial class NestedSkillView : SkillView
{
  [Export] public SkillDropPreview dropPreview;
  [Export] public Control skillsContainer;

  // Called when the node enters the scene tree for the first time.
  // public override void _Ready()
  // {
  //   base._Ready();
  // SkillListGlobal.instance.DragStarted += dropPreview.ShowDropPreview;
  // SkillListGlobal.instance.DragEnded += dropPreview.HideDropPreview;
  // }

  public void AddChildSkill(SkillResource skillResource)
  {
    var child = skillResource.inventoryScene.Instantiate<SkillView>();
    // child.Init(this, skillResource);

    skillsContainer.AddChild(child);
  }
}
