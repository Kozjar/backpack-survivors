using Godot;
using System;

public partial class VengenceCascadeBuff : Buff
{
  public VengenceCascadeBuff(SkillResource skillResource) : base(skillResource)
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
    var targetPosition = -SkillListGlobal.GetPlayerDirection(attack.GlobalPosition);
    attack.attackBehaviour.InitializePosition(attack.GlobalPosition, targetPosition);
  }
}
