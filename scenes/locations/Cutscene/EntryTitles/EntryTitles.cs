using Godot;
using System;

public partial class EntryTitles : Cutscene
{
  [Export] Label teamTitle;

  public override void _Ready()
  {
    base._Ready();
    var tween = GetTree().CreateTween();
    tween.SetPauseMode(Tween.TweenPauseMode.Process);

    teamTitle.Modulate = new Color(1, 1, 1, 0); // start transparent
    tween.TweenProperty(teamTitle, "modulate:a", 1, 2f);
    tween.TweenCallback(Callable.From(OnTweenTitleFinished));
  }

  public override void _Process(double delta)
  {
    base._Process(delta);
  }

  void OnTweenTitleFinished()
  {
    GetTree().CreateTimer(0.5f).Timeout += () =>
    {
      EmitSignal(SignalName.Finished);
    };
  }
}



