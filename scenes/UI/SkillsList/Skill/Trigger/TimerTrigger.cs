using Godot;
using System;
using System.Collections.Generic;

public partial class TimerTrigger : Trigger
{
  public TimerTrigger(TriggerResource skillResource, AttackSkill attack) : base(skillResource, attack)
  {
  }

  public override void ApplyTrigger(Attack attack, LinkedListNode<Trigger> triggerNode)
  {
    base.ApplyTrigger(attack, triggerNode);

    SkillListGlobal.instance.GetTree().CreateTimer(1d, false).Timeout += () =>
    {
      GD.Print("time");
      FireAttack(triggerNode, null);
      ApplyTrigger(null, triggerNode);
    };
  }
}
