using Godot;
using System;

public class UnitStat
{
  public delegate void ValueChangedHandler(float value);
  public event ValueChangedHandler ValueChangedEvent;
  public string title;
  public float baseValue;
  protected float value;

  public float Value
  {
    get { return value; }
    set
    {
      this.value = value;
      ValueChangedEvent?.Invoke(value);
    }
  }

  public UnitStat(float value, string title = "")
  {
    this.value = value;
    this.title = title;
    baseValue = value;
  }

  public virtual void SetBase(float baseValue){
    this.baseValue = baseValue;
    Value = baseValue;
  }

  public void UpdateByType(StatChangeType type, float value) {
    switch (type)
    {
      case StatChangeType.Increase:
        Increase(value);
        break;
      case StatChangeType.Flat:
        Flat(value);
        break;
      case StatChangeType.More:
        More(value);
        break;
      default:
        break;
    }
  }

  public void Flat(float flat)
  {
    Value += flat;
  }

  public void Increase(float increased)
  {
    Value += baseValue * increased;
  }

  public void More(float more)
  {
    Value *= 1 + more;
  }

  public void RevertByType(StatChangeType type, float value) {
    switch (type)
    {
      case StatChangeType.Increase:
        RevertFlat(value);
        break;
      case StatChangeType.Flat:
        RevertIncrease(value);
        break;
      case StatChangeType.More:
        RevertMore(value);
        break;
      default:
        break;
    }
  }

  public void RevertFlat(float flat)
  {
    Value -= flat;
  }

  public void RevertIncrease(float increased)
  {
    Value -= baseValue * increased;
  }

  public void RevertMore(float more)
  {
    Value /= 1 + more;
  }

  public virtual void Reset() {
    Value = baseValue;
  }
}
