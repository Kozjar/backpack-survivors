using Godot;
using System;

public abstract class StatSkill : SkillAbstract
{
  protected float amountPerLevel;
  StatType statName;

  public float TotalAmount => amountPerLevel * level;


  public StatSkill(string title, string description, StatType statName, float amount, int maxLevel = 5, SkillPriority priority = SkillPriority.Default): base(title, description, maxLevel, priority)
  {
    this.statName = statName;
    this.amountPerLevel = amount;
    this.priority = SkillPriority.Flat;
  }

  protected UnitStat GetSkillStat(UnitStatGroup playerStatGroup) => playerStatGroup.GetStat(statName);
}
