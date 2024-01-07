using Godot;
using System;
using System.Collections.Generic;

public partial class Trigger : SkillData
{
  [Signal] public delegate void AttackCreatedEventHandler(Attack attack);
  public Trigger(TriggerResource skillResource, AttackSkill attack) : base(skillResource)
  {
    Attack = attack;
  }

  public AttackSkill Attack { get; set; }

  public virtual void ApplyTrigger(Attack attack, LinkedListNode<Trigger> triggerNode)
  {

  }

  public override void Reset()
  {
    Attack = null;
  }

  public Attack FireAttack(LinkedListNode<Trigger> triggerNode, Vector2? _position, Node2D excludeEnemy = null)
  {
    if (Attack == null)
    {
      return null;
    }
    var position = _position == null ? SkillListGlobal.instance.player.GlobalPosition : _position.Value;
    var attackNode = Attack.CreateAttack(SkillListGlobal.instance.projectilesContainer, position, excludeEnemy);
    // attackNode.LookAt(attackNode.GlobalPosition - SkillListGlobal.instance.GetClosestEnemy(attackNode, excludeEnemy));
    SkillListGlobal.instance.OnAttack(attackNode);
    // EmitSignal(SignalName.AttackCreated, attackNode);

    if (!attackNode.attackBehaviour.initialized)
    {
      attackNode.attackBehaviour.InitializePosition(position);
    }

    if (triggerNode.Next != null)
    {
      triggerNode.Next.Value.ApplyTrigger(attackNode, triggerNode.Next);
    }

    return attackNode;
  }
}
