using Godot;
using System;

public partial class EntryTitles : Cutscene
{
  [Export] Label teamTitle;

  public override void _Ready()
  {
    base._Ready();
    var tween = GetTree().CreateTween();

    teamTitle.Modulate = new Color(1, 1, 1, 0); // start transparent
    tween.TweenProperty(teamTitle, "modulate:a", 1, 3);
    // tween.TweenCallback(Callable.From(OnTeamTitleFinished));
  }

  public override void _Process(double delta)
  {
    base._Process(delta);
  }

  void OnTeamTitleFinished()
  {
    GD.Print("OntweekTitleFinished");
    // GetTree().CreateTimer(2).Timeout += () =>
    // {
    //   GD.Print("OnTeamTitleFinished");
    //   EmitSignal(SignalName.Finished);
    // };
  }
}



