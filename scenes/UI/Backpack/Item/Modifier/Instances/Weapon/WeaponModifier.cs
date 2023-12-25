using Godot;
using System;

public partial class WeaponModifier : ItemModifier, IBackpackItemModifier
{
  [Export] PackedScene attacker;
  [Export] PackedScene attackScene;
  [Export] public WeaponStats stats;
  AttackComponent WeaponInstance;

  public override void _Ready()
  {

    var itemData = GetParent<BackpackItemData>();
    itemData.AddedToBackpack += Apply;
    itemData.RemovedFromBackpack += Undo;
  }

  public void Apply()
  {
    var player = GetTree().Root.GetNode<Player>("root/Elements/Player");
    WeaponInstance = attacker.Instantiate<AttackComponent>();

    WeaponInstance.attackScene = attackScene;
    WeaponInstance.character = player;
    WeaponInstance.statsComponent = stats;

    player.AddChild(WeaponInstance);
  }

  public void Undo()
  {
    stats.StatGroup.ResetStats();
    WeaponInstance.QueueFree();
  }
}
