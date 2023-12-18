using Godot;
using System;

public partial class StatsList : VBoxContainer
{
  [Export] StatsComponent statsComponent;
  [Export] PackedScene statRowAsset;

  public override void _Ready()
  {
    var stats = statsComponent.statGroup.stats.Values;

    foreach (var stat in stats)
    {
      var statRowScene = statRowAsset.Instantiate<StatRow>();
      AddChild(statRowScene);

      statRowScene.Init(stat);
    }
  }
}
