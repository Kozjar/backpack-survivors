using Godot;
using System;

public partial class VengenceCascadeBuffResource : BuffResource
{
  public override SkillData CreateInstance()
  {
    return new VengenceCascadeBuff(this);
  }
}
