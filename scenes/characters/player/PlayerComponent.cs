using Godot;

public partial class PlayerComponent : Node {
  [Export] StatsComponent statsComponent;

  public override void _Ready()
  {
    statsComponent.statGroup = new PlayerStatGroup();
  }
}
