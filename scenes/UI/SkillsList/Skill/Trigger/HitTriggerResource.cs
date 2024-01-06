using Godot;
using System;

public partial class HitTriggerResource : TriggerResource
{
  public override HitTrigger CreateInstance(AttackSkill attack)
  {
    return new HitTrigger(this, attack);
  }
}
