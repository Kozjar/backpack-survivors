using Godot;
using System;
using System.Collections.Generic;

public partial class AttackTriggerData : GodotObject
{
  public Node2D enemy;
  public LinkedListNode<Trigger> triggerNode;

  public AttackTriggerData(LinkedListNode<Trigger> triggerNode, Node2D enemy)
  {
    this.enemy = enemy;
    this.triggerNode = triggerNode;
  }
}

public partial class HitTrigger : Trigger
{
  public HitTrigger(TriggerResource skillResource, AttackSkill attack) : base(skillResource, attack)
  {
  }

  public override void ApplyTrigger(Attack attack, LinkedListNode<Trigger> triggerNode)
  {
    base.ApplyTrigger(attack, triggerNode);
    attack.DamageDealt += (enemy) => CallDeferred(MethodName.OnAttack, new AttackTriggerData(triggerNode, enemy));
  }

  void OnAttack(AttackTriggerData data)
  {
    FireAttack(data.triggerNode, data.enemy.Position, data.enemy);
  }
}
