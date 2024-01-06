using Godot;
using System;
using System.Collections.Generic;

public partial class PeriodicHit : Node
{
  [Signal] public delegate void DamageDealEventHandler(DamageReceiveComponent receiver);
  [Export] public double cooldownTime = 1f;
  List<Area2D> targetsInArea = new List<Area2D>();
  List<Area2D> targetsOnCooldown = new List<Area2D>();

  public void OnEnterAttackArea(Area2D damageReceiver)
  {
    targetsInArea.Add(damageReceiver);

    if (!targetsOnCooldown.Contains(damageReceiver))
    {
      HitTarget(damageReceiver);
    }
  }

  void HitTarget(Area2D target)
  {
    EmitSignal(SignalName.DamageDeal, (DamageReceiveComponent)target);
    StartHitCooldown(target);
  }

  public void OnLeaveAttackArea(Area2D damageReceiver)
  {
    targetsInArea.Remove(damageReceiver);
  }

  public void StartHitCooldown(Area2D damageReceiver)
  {
    targetsOnCooldown.Add(damageReceiver);

    GetTree().CreateTimer(cooldownTime, false).Timeout += () =>
    {
      targetsOnCooldown.Remove(damageReceiver);

      if (targetsInArea.Contains(damageReceiver))
      {
        HitTarget(damageReceiver);
      }
    };
  }
}
