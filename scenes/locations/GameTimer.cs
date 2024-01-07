using Godot;
using System;

public partial class GameTimer : Control
{
  [Signal] public delegate void TimePassedEventHandler(int time);
  [Export] Timer timer;
  [Export] Label timerLabel;
  int remainingTime;

  public override void _Ready()
  {
    base._Ready();
    ResetTime();
    UpdateTimerText();
  }

  void ResetTime()
  {
    remainingTime = SkillListGlobal.gameTime;
    timer.Start();
  }

  public void SubtractSecond()
  {
    remainingTime--;
    EmitSignal(SignalName.TimePassed, SkillListGlobal.gameTime - remainingTime);
    if (remainingTime <= 0)
    {
      timer.Stop();
    }
    else
    {
      UpdateTimerText();
    }
  }

  void UpdateTimerText()
  {
    var seconds = remainingTime % 60;
    var secondsText = seconds > 10 ? seconds.ToString() : "0" + seconds.ToString();
    timerLabel.Text = $"{Math.Floor((double)(remainingTime / 60))}:{secondsText}";
  }
}
