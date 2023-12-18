using Godot;
using System;

public class IncreaseStatSkill : StatSkill
{

  public IncreaseStatSkill(string title, string description, StatType statName, float amount, int maxLevel = 5) : base(title, description, statName, amount, maxLevel, SkillPriority.Flat) {}

  public override void ModifyStats(UnitStatGroup playerStats)
  {
    GetSkillStat(playerStats).Increase(TotalAmount);
  }
}
