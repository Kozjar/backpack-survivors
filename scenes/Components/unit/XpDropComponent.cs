using Godot;

public partial class XpDropComponent : Node
{
  [Export] StatsComponent statsComponent;
  [Export] public PackedScene xpScene;
  [Export] public Node2D entityRoot;
  [Export] public int xpGain = 1;

  public override void _Ready()
  {
    statsComponent.statGroup.HealthDepletedEvent += () => CallDeferred("SpawnXPNode");
  }

  private void SpawnXPNode()
  {
    var xp = xpScene.Instantiate<Experience>();
    xp.GlobalPosition = entityRoot.GlobalPosition;
    xp.amount = xpGain;

    entityRoot.GetParent().AddChild(xp);
  }
}
