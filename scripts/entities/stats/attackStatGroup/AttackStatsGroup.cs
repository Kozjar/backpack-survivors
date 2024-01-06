using Godot;

public class AttackStatGroup
{
  public delegate void PiercedLastTargetHandler();
  public event PiercedLastTargetHandler PiercedLastTargetEvent;
  public float damage;
  public float critChance;
  public float critDamage;
  // public float pierce;

  public AttackStatGroup(StatGroup stats)
  {
    this.damage = stats.GetStat(StatType.Damage).Value;
    this.critChance = stats.GetStat(StatType.CritChance).Value;
    this.critDamage = stats.GetStat(StatType.CritDamage).Value;
    // this.pierce = stats.GetStat(StatType.Pierce).Value;
  }

  public AttackStatGroup(float damage, float critChance, float critDamage)
  {
    this.damage = damage;
    this.critChance = critChance;
    this.critDamage = critDamage;
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
    var critMulti = GD.Randf() <= critChance ? critDamage : 1;

    return damage * critMulti;
  }
}