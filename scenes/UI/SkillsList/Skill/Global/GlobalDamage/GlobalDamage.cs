using Godot;
using System;

public partial class GlobalDamage : Node
{
  float damageMultiplier = 0.3f;
  public override void _Ready()
  {
    base._Ready();
    SkillListGlobal.instance.AttackCreated += OnAttack;
    TreeExited += () => SkillListGlobal.instance.AttackCreated -= OnAttack;
  }

  void OnAttack(Attack attack)
  {
    attack.attackStatGroup.damage.More(damageMultiplier);
  }
}
