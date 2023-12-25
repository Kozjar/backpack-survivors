using Godot;
using System;

public partial class WeaponStats : Node, IWeaponComponent
{
  [Export] float damage = 10;
  [Export] float attackSpeed = 1;
  [Export] float critChance = 0;
  [Export] float critDamage = 1;
  private StatGroup statGroup = new();
  public StatGroup StatGroup => statGroup;

  public override void _Ready()
  {
    statGroup.stats.Add(StatType.AttackSpeed, new UnitStat(attackSpeed, "Attack Speed"));
    statGroup.stats.Add(StatType.Damage, new UnitStat(damage, "Damage"));
    statGroup.stats.Add(StatType.CritChance, new UnitStat(critChance, "Crit Chance"));
    statGroup.stats.Add(StatType.CritDamage, new UnitStat(critDamage, "Crit Damage"));
    base._Ready();
  }
}
