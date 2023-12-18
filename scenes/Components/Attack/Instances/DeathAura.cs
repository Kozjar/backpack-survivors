using Godot;
using System;
using System.Collections.Generic;

public partial class DeathAura : Area2D, IAttack
{
  [Export] StatsComponent statsComponent;
  AttackStatGroup attackStatGroup;

  public override void _Ready()
  {
    UpdateAttackStats();
  }

  public float? EmitHit()
  {
    return attackStatGroup.EmitHit();
  }

  public void UpdateAttackStats()
  {
    attackStatGroup = new AttackStatGroup(statsComponent.statGroup);
  }

  public void DealDamage(Area2D damageReceiver)
  {
    ((DamageReceiveComponent)damageReceiver).OnReceiveDamage(this);
  }
}
