using Godot;
using System;
using System.Security.Cryptography;

public partial class StatRow : HBoxContainer
{
  [Export] Label title;
  [Export] Label amount;
  [Export] Label diff;
  [Export] Label currentAmount;

  public void Init(UnitStat stat) {
    UpdateData(stat);
    stat.ValueChangedEvent += (float value) => UpdateData(stat);
    
    if (stat is ConsumableStat) {
      ((ConsumableStat)stat).CurrentValueChangedEvent += UpdateCurrentValue;
    } else {
      currentAmount?.QueueFree();
    }
  }

  public void UpdateData(UnitStat stat) {
    title.Text = $"{stat.title}:";
    amount.Text = Math.Round(stat.Value, 2).ToString();
    var diffValue = GetStatDiff(stat);
    diff.Text = diffValue == 0 ? null : $"({diffValue}%)";
  }

  public void UpdateCurrentValue(float value) {
    currentAmount.Text = $"{value} /";
  }

  private int GetStatDiff(UnitStat stat) {
    return (int)Math.Round((stat.Value / stat.baseValue - 1) * 100);
  }
}
