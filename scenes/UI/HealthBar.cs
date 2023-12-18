using Godot;
using System;

public partial class HealthBar : ProgressBar
{
  [Export] StatsComponent statsComponent;

  public override void _Ready()
  {
    MaxValue = statsComponent.statGroup.Health.Value;
    Value = statsComponent.statGroup.Health.CurrentValue;
    UpdateVisability();

    statsComponent.statGroup.Health.CurrentValueChangedEvent += (float value) => { Value = value; UpdateVisability(); };
  }

  private void UpdateVisability()
  {
    Visible = MaxValue != Value && Value > 0;
  }
}
