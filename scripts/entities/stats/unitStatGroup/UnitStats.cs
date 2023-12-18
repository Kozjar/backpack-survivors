
using System.Collections.Generic;

public class UnitStatGroup {
  public delegate void StatsChangedHandler();
  public delegate void HealthDepletedHandler();
  public event HealthDepletedHandler HealthDepletedEvent;
  public event StatsChangedHandler StatsChangedEvent;
  public Dictionary<StatType, UnitStat> stats = new(){
    { StatType.Health, new ConsumableStat(100, "Health") },
  };
  public ConsumableStat Health => (ConsumableStat)stats[StatType.Health];

  public UnitStatGroup() {
    Health.CurrentValueChangedEvent += (float value) => {
      if (value <= 0) HealthDepletedEvent?.Invoke();
    };
  }

  public void TakeDamage(float damage) {
    Health.CurrentValue -= damage;
  }

  public void Heal(float amount) {
    Health.CurrentValue += amount;
  }

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

  public void UpdateConsumables() {
    foreach (var stat in stats.Values)
    {
      if (stat is ConsumableStat) ((ConsumableStat)stat).UpdateCurrent();
    }
  }

  public void ApplySkills(List<SkillAbstract> skills) {
    ResetStats();

    skills.Sort((a, b) => a.CompareTo(b));
    foreach (var skill in skills)
    {
      skill.ModifyStats(this);
    }

    StatsChangedEvent?.Invoke();
    UpdateConsumables();
  }
}
