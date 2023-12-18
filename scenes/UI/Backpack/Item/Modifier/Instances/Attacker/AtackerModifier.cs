using Godot;
using System;

public partial class AtackerModifier : Node, IBackpackItemModifier
{
  [Export] PackedScene attacker;
  [Export] PackedScene attackScene;
  [Export] float attackSpeed = 1f;

  public void Apply()
  {
    var player = GetTree().Root.GetNode<Player>("root/Elements/Player");
    var attackerInstance = attacker.Instantiate<AttackComponent>();
    attackerInstance.attackScene = attackScene;
    attackerInstance.character = player;
    attackerInstance.statsComponent = GetTree().Root.GetNode<DefinedStatsComponent>("root/Elements/Player/Stats");
    attackerInstance.timer.WaitTime = attackSpeed;

    player.AddChild(attackerInstance);
  }
}
