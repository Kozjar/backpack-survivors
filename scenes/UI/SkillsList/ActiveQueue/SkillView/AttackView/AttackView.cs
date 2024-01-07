using Godot;
using System;

public partial class AttackView : NestedSkillView
{
  public AttackSkill Attack => (AttackSkill)skillData;

  public override void _Ready()
  {
    base._Ready();
    SkillListGlobal.instance.DragStarted += OnDragStarted;
    dropPreview.skillDropped += OnBuffDropped;
  }

  public override void _ExitTree()
  {
    base._ExitTree();
    SkillListGlobal.instance.DragStarted -= OnDragStarted;
  }

  void OnBuffDropped(SkillDragData skillDragData)
  {
    // if (skillDragData.previousParent != this)
    // {

    // }
    AddSkill(skillDragData.skillData);
  }

  void OnDragStarted(SkillData skillData)
  {
    if (skillData is Buff buff && buff.CanAttach(Attack))
    {
      dropPreview.ShowDropPreview();
    }
  }

  public override void AddSkill(SkillData skillData)
  {
    if (skillData is Buff buff)
    {
      buff.Apply(Attack);
      base.AddSkill(skillData);
      Attack.buffs.Add(buff);
    }
  }

  public override void RemoveSkill(SkillData skillData)
  {
    base.RemoveSkill(skillData);
    if (skillData is Buff buff)
    {
      buff.Undo(Attack);
      Attack.buffs.Remove((Buff)skillData);
    }
  }
}
