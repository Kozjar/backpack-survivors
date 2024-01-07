using Godot;
using System;

public partial class GlobalMoreCritChance : Node
{
  float critMultiplier = 1f;
  public override void _Ready()
  {
    base._Ready();
    SkillListGlobal.instance.AttackCreated += OnAttack;
    TreeExited += () => SkillListGlobal.instance.AttackCreated -= OnAttack;
  }

  void OnAttack(Attack attack)
  {
    attack.attackStatGroup.critChance.Increase(critMultiplier);
  }
}
