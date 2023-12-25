using System.Collections.Generic;

public class StatGroup {
  public Dictionary<StatType, UnitStat> stats = new();

  public UnitStat GetStat(StatType statKey)
  {
    return stats[statKey];
  }

  public void ResetStats() {
    foreach (var stat in stats.Values)
    {
      stat.Reset();
    }
  }
}
