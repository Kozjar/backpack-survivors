using Godot;
using System;

public partial class AttackResource : SkillResource
{
  [Export] public PackedScene attackScene;
  [Export] public float damage;

  public override AttackSkill CreateInstance()
  {
    return new AttackSkill(this);
  }
}
