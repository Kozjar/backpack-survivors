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

  public UnitStat(float value, string title)
  {
    this.value = value;
    this.title = title;
    baseValue = value;
  }

  public virtual void SetBase(float baseValue){
    this.baseValue = baseValue;
    Value = baseValue;
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

  public virtual void Reset() {
    Value = baseValue;
  }
}
