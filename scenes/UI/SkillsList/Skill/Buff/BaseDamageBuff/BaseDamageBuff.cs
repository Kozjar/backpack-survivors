using Godot;
using System;

public partial class BaseDamageBuff : Buff
{
  public float damageIncrease = 0.3f;

  public BaseDamageBuff(SkillResource skillResource) : base(skillResource)
  {
  }

  public override void Apply(AttackSkill attack)
  {
    base.Apply(attack);
    attack.AttackCreated += OnAttack;
  }

  public override void Undo(AttackSkill attack)
  {
    base.Undo(attack);
    attack.AttackCreated -= OnAttack;
  }

  void OnAttack(Attack attack)
  {
    attack.attackStatGroup.damage.Increase(damageIncrease);
  }
}
