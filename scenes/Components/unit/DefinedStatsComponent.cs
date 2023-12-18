using Godot;

public partial class DefinedStatsComponent : StatsComponent
{
  [Export] float health = 100;
  [Export] float damage = 10;
  [Export] float attackSpeed = 1;
  [Export] float area = 1;
  [Export] float critChance = 0;
  [Export] float critDamage = 1;
  [Export] float speed = 100;

  public override void _Ready()
  {
    statGroup.stats.Add(StatType.AttackSpeed, new UnitStat(attackSpeed, "Attack Speed"));
    statGroup.stats.Add(StatType.Damage, new UnitStat(damage, "Damage"));
    statGroup.stats.Add(StatType.Area, new UnitStat(area, "Area"));
    statGroup.stats.Add(StatType.CritChance, new UnitStat(critChance, "Crit Chance"));
    statGroup.stats.Add(StatType.CritDamage, new UnitStat(critDamage, "Crit Damage"));
    statGroup.stats.Add(StatType.Speed, new UnitStat(speed, "Speed"));
    statGroup.stats[StatType.Health].SetBase(health);
    base._Ready();
  }
}
