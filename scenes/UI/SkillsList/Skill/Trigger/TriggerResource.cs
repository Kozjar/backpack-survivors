using Godot;
using System;

public partial class TriggerResource : SkillResource
{
  public virtual Trigger CreateInstance(AttackSkill attack)
  {
    return new Trigger(this, attack);
  }


  public override Trigger CreateInstance()
  {
    return CreateInstance(null);
  }
}
