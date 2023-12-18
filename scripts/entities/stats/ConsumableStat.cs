public class ConsumableStat : UnitStat
{
  public event ValueChangedHandler CurrentValueChangedEvent;
  private float currentValue;
  private float resetValue;

  public float CurrentValue
  {
    get { return currentValue; }
    set
    {
      this.currentValue = value;
      CurrentValueChangedEvent?.Invoke(value);
    }
  }

  public ConsumableStat(float value, string title) : base(value, title)
  {
    currentValue = value;
  }

  public void UpdateCurrent()
  {
    var diff = resetValue - Value;

    if (diff == 0) return;
    if (currentValue > Value) currentValue = Value;
    if (diff > 0) currentValue += diff;
  }

  public override void Reset()
  {
    resetValue = Value;
    base.Reset();
  }

    public override void SetBase(float baseValue)
    {
        base.SetBase(baseValue);
        CurrentValue = Value;
    }
}
