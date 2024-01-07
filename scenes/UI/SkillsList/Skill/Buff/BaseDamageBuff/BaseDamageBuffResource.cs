using Godot;
using System;

public partial class BaseDamageBuffResource : BuffResource
{
  public override SkillData CreateInstance()
  {
    return new BaseDamageBuff(this);
  }
}
