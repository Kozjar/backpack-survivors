using Godot;
using System;
using System.Collections.Generic;

public partial class EndTrigger : Trigger
{
  public EndTrigger(TriggerResource skillResource, AttackSkill attack) : base(skillResource, attack)
  {
  }

  public override void ApplyTrigger(Attack attack, LinkedListNode<Trigger> triggerNode)
  {
    base.ApplyTrigger(attack, triggerNode);
    attack.TreeExited += () => FireAttack(triggerNode, attack.Position);
  }
}
