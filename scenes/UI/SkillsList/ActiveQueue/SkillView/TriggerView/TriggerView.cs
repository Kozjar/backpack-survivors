using Godot;
using System;

public partial class TriggerView : NestedSkillView
{
  public Trigger Trigger => (Trigger)skillData;
  // [Export] NestedSkillView nestedSkillView;
  public override void _Ready()
  {
    base._Ready();
    AddSkill(Trigger.Attack);

    SkillListGlobal.instance.DragStarted += OnDragStarted;
    dropPreview.skillDropped += OnAttackDropped;
  }

  void OnAttackDropped(SkillDragData dragData)
  {
    if (Trigger.Attack != null && dragData.previousParent != this)
    {
      dragData.previousParent.AddSkill(Trigger.Attack);
      RemoveSkill(Trigger.Attack);
    }
    AddSkill(dragData.skillData);
  }

  public override void _ExitTree()
  {
    base._ExitTree();
    SkillListGlobal.instance.DragStarted -= OnDragStarted;
  }

  void OnDragStarted(SkillData skillData)
  {
    if (skillData is AttackSkill)
    {
      dropPreview.ShowDropPreview();
    }
  }

  public override void AddSkill(SkillData skillData)
  {
    if (skillData is AttackSkill)
    {
      base.AddSkill(skillData);
      Trigger.Attack = (AttackSkill)skillData;
    }
  }

  public override void RemoveSkill(SkillData skillData)
  {
    if (skillData == Trigger.Attack)
    {
      base.RemoveSkill(skillData);
      Trigger.Attack = null;
    }
  }
}
