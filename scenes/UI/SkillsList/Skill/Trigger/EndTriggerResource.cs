using Godot;
using System;

public partial class EndTriggerResource : TriggerResource
{
  public override Trigger CreateInstance(AttackSkill attack)
  {
    return new EndTrigger(this, attack);
  }
}
