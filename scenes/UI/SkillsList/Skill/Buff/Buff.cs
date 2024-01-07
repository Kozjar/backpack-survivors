using Godot;
using System;

public partial class Buff : SkillData
{
  public Buff(SkillResource skillResource) : base(skillResource)
  {
  }

  public virtual void Apply(AttackSkill attack)
  {

  }

  public virtual void Undo(AttackSkill attack)
  {

  }

  public virtual bool CanAttach(AttackSkill attack)
  {
    return true;
  }
}
