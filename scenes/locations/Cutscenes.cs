using Godot;
using System;

public partial class Cutscenes : Node
{
  [Export] PackedScene entryTitles;
  [Export] PackedScene exposition;
  [Export] PackedScene departure;
  [Export] PackedScene arrival;
  [Export] PackedScene firstBossMeet;
  [Export] PackedScene finalBossMeet;
  [Export] PackedScene ending;
  [Export] PackedScene death;
  [Export] Node container;

  Cutscene currentCutscene = null;

  public override void _Ready()
  {
    base._Ready();

    // ShowCutscene(arrival);

    // var entryTitlesNode = ShowCutscene(entryTitles);
    // entryTitlesNode.Finished += () =>
    // {
    //   var expositionNode = ShowCutscene(exposition);
    //   expositionNode.Finished += () =>
    //   {
    //     var departureNode = ShowCutscene(arrival);

    //     departureNode.Finished += () =>
    //     {
    //       StartGame();
    //     };
    //   };
    // };
  }

  Cutscene ShowCutscene(PackedScene scene)
  {
    ClearCurrentCutscene();
    SkillListGlobal.instance.PauseGameplay();
    currentCutscene = scene.Instantiate<Cutscene>();
    container.AddChild(currentCutscene);

    return currentCutscene;
  }


  void StartGame()
  {
    ClearCurrentCutscene();
    SkillListGlobal.instance.ResumeGameplay();
  }

  void ClearCurrentCutscene()
  {
    if (currentCutscene != null)
    {
      currentCutscene.QueueFree();
      currentCutscene = null;
    }
  }

  public void OnPlayerDeath()
  {
    // SkillListGlobal.instance.PauseGameplay();
    // ShowCutscene(death);
  }
}
