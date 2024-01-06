using Godot;
using System;

public partial class SkillView : PanelContainer
{
  [Export] public Label nameNode;
  [Export] public SkillData skillData;
  [Export] public SkillDraggableTitle skillDraggableTitle;
  public ISkillContainer parent;

  public virtual void Init(ISkillContainer parent, SkillData skillData)
  {
    this.parent = parent;
    this.skillData = skillData;
  }

  public override void _Ready()
  {
    nameNode.Text = skillData.skillResource.Name;
    skillDraggableTitle.Init(parent, skillData);
  }
}
