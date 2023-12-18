using Godot;
using System;

public enum StatChangeType
{
  Increase,
  Flat,
  More,
}

public class SimpleSkill : SkillAbstract
{
  StatChangeType changeType;
  float amount;
  StatType statName;

  public SimpleSkill(string title, string description, StatType statName, StatChangeType changeType, float amount, int maxLevel = 1): base(title, description, maxLevel)
  {
    this.statName = statName;
    this.changeType = changeType;
    this.amount = amount;
  }

  public override void ModifyStats(UnitStatGroup playerStats)
  {
    var stat = playerStats.GetStat(statName);

    switch (changeType)
    {
      case StatChangeType.Increase:
        stat.Increase(amount * level);
        break;
      case StatChangeType.Flat:
        stat.Flat(amount * level);
        break;
      case StatChangeType.More:
        stat.More(amount * level);
        break;
      default:
        break;
    }
  }
}
