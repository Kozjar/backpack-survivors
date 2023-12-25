
using System.Collections.Generic;

public class UnitStatGroup : StatGroup
{
  public delegate void StatsChangedHandler();
  public delegate void HealthDepletedHandler();
  public event HealthDepletedHandler HealthDepletedEvent;
  public event StatsChangedHandler StatsChangedEvent;
  public ConsumableStat Health => (ConsumableStat)stats[StatType.Health];

  public UnitStatGroup()
  {
    stats = new() { { StatType.Health, new ConsumableStat(100, "Health") }, };

    Health.CurrentValueChangedEvent += (float value) =>
    {
      if (value <= 0) HealthDepletedEvent?.Invoke();
    };
  }

  public void TakeDamage(float damage)
  {
    Health.CurrentValue -= damage;
  }

  public void Heal(float amount)
  {
    Health.CurrentValue += amount;
  }

  public void UpdateConsumables()
  {
    foreach (var stat in stats.Values)
    {
      if (stat is ConsumableStat) ((ConsumableStat)stat).UpdateCurrent();
    }
  }

  public void ApplySkills(List<SkillAbstract> skills)
  {
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
