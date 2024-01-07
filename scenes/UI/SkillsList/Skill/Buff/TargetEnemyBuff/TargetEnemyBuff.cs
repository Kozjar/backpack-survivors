using Godot;
using System;

public partial class TargetEnemyBuff : Buff
{
  public TargetEnemyBuff(SkillResource skillResource) : base(skillResource)
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
    var targetPosition = SkillListGlobal.instance.GetClosestEnemy(attack, attack.excludeEnemy);
    attack.attackBehaviour.InitializePosition(attack.GlobalPosition, targetPosition);
  }
}
