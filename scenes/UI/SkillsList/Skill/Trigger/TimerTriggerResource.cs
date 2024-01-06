using Godot;
using System;

public partial class TimerTriggerResource : TriggerResource
{
  public override TimerTrigger CreateInstance(AttackSkill attack)
  {
    return new TimerTrigger(this, attack);
  }
  // public override void ApplyTrigger(Attack attack)
  // {
  //   base.ApplyTrigger(attack);
  //   SkillListGlobal.instance.GetTree().CreateTimer(1d).Timeout += () =>
  //   {
  //     GD.Print("time");
  //     ApplyTrigger(null);
  //   };
  // }
}
