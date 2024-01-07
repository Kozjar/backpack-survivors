using Godot;

public partial class StatsComponent : Node
{
  [Signal] public delegate void HealthDepletedEventHandler();

  public UnitStatGroup statGroup = new();

  public override void _Ready()
  {
    base._Ready();
    statGroup.HealthDepletedEvent += () => EmitSignal(SignalName.HealthDepleted);
  }
}
