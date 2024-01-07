using Godot;

public class AttackStatGroup
{
  public delegate void PiercedLastTargetHandler();
  public event PiercedLastTargetHandler PiercedLastTargetEvent;
  public UnitStat damage;
  public UnitStat critChance;
  public UnitStat critDamage;
  // public float pierce;

  public AttackStatGroup(StatGroup stats)
  {
    this.damage = new UnitStat(stats.GetStat(StatType.Damage).Value);
    this.critChance = new UnitStat(stats.GetStat(StatType.CritChance).Value);
    this.critDamage = new UnitStat(stats.GetStat(StatType.CritDamage).Value);
    // this.pierce = stats.GetStat(StatType.Pierce).Value;
  }

  public AttackStatGroup(float damage, float critChance, float critDamage)
  {
    this.damage = new UnitStat(damage);
    this.critChance = new UnitStat(critChance);
    this.critDamage = new UnitStat(critDamage);
    // this.pierce = stats.GetStat(StatType.Pierce).Value;
  }

  public float? EmitHit()
  {
    // pierce -= 1;
    // if (pierce < 0)
    // {
    //   PiercedLastTargetEvent?.Invoke();

    //   return null;
    // }

    return CalculateDamage();
  }

  private float CalculateDamage()
  {
    var critMulti = GD.Randf() <= critChance.Value ? critDamage.Value : 1;

    return damage.Value * critMulti;
  }
}