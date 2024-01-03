using Godot;
using System;

public partial class SkillView : PanelContainer
{
  [Export] public Label nameNode;
  [Export] public SkillResource skillResource;
  [Export] public SkillDraggableTitle skillDraggableTitle;
  public ISkillContainer parent;

  // public virtual void Init(ISkillContainer parent, SkillResource skillResource) {
  // 	this.parent = parent;
  // 	this.skillResource = skillResource;
  // }

  public override void _Ready()
  {
    nameNode.Text = skillResource.Name;
    skillDraggableTitle.Init(parent, skillResource);
  }
}
