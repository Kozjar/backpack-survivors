using Godot;
using System;

public partial class TargetEnemyBuffResource : BuffResource
{
  public override SkillData CreateInstance()
  {
    return new TargetEnemyBuff(this);
  }
}
