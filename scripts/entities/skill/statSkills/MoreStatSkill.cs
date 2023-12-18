using Godot;
using System;

public class MoreStatSkill : StatSkill
{

  public MoreStatSkill(string title, string description, StatType statName, float amount, int maxLevel = 3) : base(title, description, statName, amount, maxLevel, SkillPriority.More) {}

  public override void ModifyStats(UnitStatGroup playerStats)
  {
    for (int i = 0; i < level; i++)
    {
      GetSkillStat(playerStats).More(amountPerLevel);
    }
  }
}
