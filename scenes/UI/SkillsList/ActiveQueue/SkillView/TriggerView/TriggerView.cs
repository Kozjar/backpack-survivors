using Godot;
using System;

public partial class TriggerView : NestedSkillView
{
  // public void Init(ISkillContainer parent, Trigger trigger)
  // {
  // base.Init(parent, trigger.skillResource);
  //   if (trigger.Attack != null)
  //   {
  //     AddAttack(trigger.Attack);
  //   }
  // }

  public void AddAttack(AttackSkill attack)
  {
    AddChildSkill(attack.skillResource);
  }
}
