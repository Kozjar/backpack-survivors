using Godot;
using System;

public partial class SkillDragPreview : Control
{
  [Export] public SkillTitleView skillTitleView;

  public override void _Ready()
  {
    SkillListGlobal.instance.DraggedSkill = skillTitleView.skillData;
    TreeExited += () => SkillListGlobal.instance.DraggedSkill = null;
  }


  public void Init(SkillData skillData)
  {
    skillTitleView.skillData = skillData;
  }
}
