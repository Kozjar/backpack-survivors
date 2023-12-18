using Godot;
using System;
using System.Collections.Generic;

public class PlayerStatGroup: UnitStatGroup
{
  public PlayerStatGroup() {
    stats.Add(StatType.AttackSpeed, new UnitStat(1, "Attack Speed"));
    stats.Add(StatType.Damage, new UnitStat(90, "Damage"));
    stats.Add(StatType.Area, new UnitStat(1, "Area"));
    stats.Add(StatType.Pierce, new UnitStat(1, "Pierce"));
    stats.Add(StatType.CritChance, new UnitStat(0.05f, "Crit Chance"));
    stats.Add(StatType.CritDamage, new UnitStat(1.5f, "Crit Damage"));
    stats.Add(StatType.Speed, new UnitStat(200, "Speed"));
  }
}
