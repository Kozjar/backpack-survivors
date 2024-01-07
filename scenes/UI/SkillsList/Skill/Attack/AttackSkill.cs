using Godot;
using System;
using System.Collections.Generic;

public partial class AttackSkill : SkillData
{
  [Signal] public delegate void AttackCreatedEventHandler(Attack attack);
  public List<Buff> buffs = new();
  public AttackResource attackResource => (AttackResource)skillResource;

  public AttackSkill(AttackResource skillResource) : base(skillResource)
  {
  }

  public Attack CreateAttack(Node Container, Vector2 position, Node2D excludeEnemy = null)
  {
    var attackNode = attackResource.attackScene.Instantiate<Attack>();
    attackNode.GlobalPosition = position;
    attackNode.excludeEnemy = excludeEnemy;
    attackNode.Init(new AttackStatGroup(attackResource.damage, 0, 1));
    Container.AddChild(attackNode);

    EmitSignal(SignalName.AttackCreated, attackNode);

    return attackNode;
  }

  public override void Reset()
  {
    base.Reset();
    buffs.ForEach(buff => buff.Undo(this));
    buffs.Clear();
  }
}
