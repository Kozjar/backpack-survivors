using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

// public enum SkillType
// {
//   IncreseAttack,
//   FlatAttack,
//   MoreAttack,
//   IncreaseAttackSpeed,
//   IncreaseArea,
//   IncreaseSpeed,
// }

public class SkillStore : SkillsCollection
{
  new readonly List<SkillAbstract> skills = new()
  {
    new IncreaseStatSkill("Increse Attack", "Increase attack damage by 10%", StatType.Damage, 0.1f),
    new FlatStatSkill("Add Attack", "Add 10 attack damage", StatType.Damage, 10),
    new IncreaseStatSkill("Increse Attack Speed", "Increase attack speed by 10%", StatType.AttackSpeed, 0.1f),
    new IncreaseStatSkill("Increse Area", "Increase Area by 10%", StatType.Area, 0.1f),
    new IncreaseStatSkill("Increse Movement", "Increase movement speeed by 10%", StatType.Speed, 0.1f),
    new MoreStatSkill("Attack Multiplier", "Multiply attack damage by x1.1", StatType.Damage, 0.1f),
  };

  private SkillAbstract GetRandomSkill(List<SkillAbstract> skills)
  {
    if (skills.Count == 0) return null;
    var index = GD.Randi() % skills.Count;

    return skills.ElementAt((int)index);
  }

  public List<SkillAbstract> GetSequense(int amount)
  {
    var remainingSkills = new List<SkillAbstract>(skills);
    var result = new List<SkillAbstract>();

    for (int i = 0; i < amount; i++)
    {
      var skill = GetRandomSkill(remainingSkills);

      if (skill != null)
      {
        remainingSkills.Remove(skill);
        result.Add(skill);
      }
    }

    return result;
  }

  public SkillAbstract PickSkill(SkillAbstract skill)
  {
    skill.level += 1;

    if (skill.level >= skill.maxLevel)
    {
      skills.Remove(skill);
    }

    return skill;
  }
}
