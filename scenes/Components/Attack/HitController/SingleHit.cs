using Godot;
using System;
using System.Collections.Generic;

public partial class SingleHit : Node
{
  List<Area2D> affectedTargets = new();
  [Signal] public delegate void DamageDealEventHandler(DamageReceiveComponent receiver);

  public void OnEnterAttackArea(Area2D damageReceiver)
  {
    if (!affectedTargets.Contains(damageReceiver))
    {
      affectedTargets.Add(damageReceiver);
      EmitSignal(SignalName.DamageDeal, (DamageReceiveComponent)damageReceiver);
    }
  }
}
