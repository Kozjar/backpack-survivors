using Godot;
using System;

public partial class GlobalMovementSpeed : Node
{
  float multiplier = 0.2f;
  override public void _Ready()
  {
    SkillListGlobal.instance.player.statsComponent.statGroup.GetStat(StatType.Speed).Increase(multiplier);
  }

  override public void _ExitTree()
  {
    SkillListGlobal.instance.player.statsComponent.statGroup.GetStat(StatType.Speed).RevertIncrease(multiplier);
  }
}
