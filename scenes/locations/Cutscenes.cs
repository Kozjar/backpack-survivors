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

  Cutscene currentCutscene;

  public override void _Ready()
  {
    base._Ready();

    // var entryTitlesNode = ShowCutscene(entryTitles);
    // entryTitlesNode.Finished += () =>
    // {
    //   var expositionNode = ShowCutscene(exposition);
    //   expositionNode.Finished += () =>
    //   {
    //     var departureNode = ShowCutscene(departure);

    //     departureNode.Finished += () =>
    //     {
    //       StartGame();
    //     };
    //   };
    // };
  }

  Cutscene ShowCutscene(PackedScene scene)
  {
    if (currentCutscene != null)
    {
      currentCutscene.QueueFree();
    }

    var sceneNode = scene.Instantiate<Cutscene>();
    container.AddChild(sceneNode);

    return sceneNode;
  }


  void StartGame()
  {
    //   if (currentCutscene != null)
    //   {
    //     currentCutscene.QueueFree();
    //   }

    //   SkillListGlobal.instance.ToggleGameplay();
  }
}
