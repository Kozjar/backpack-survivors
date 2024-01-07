using DialogueManagerRuntime;
using Godot;
using System;

public partial class Arrival : DialogCutscene
{
  [Signal] public delegate void SkillMenuShownEventHandler();
  [Export] Resource dialog_1;
  [Export] PackedScene balloon;

  public override void _Ready()
  {
    base._Ready();
    // var balloonNode = balloon.Instantiate<Balloon>();
    // balloonNode.Start(dialog_1);
    var balloon = ShowDialog(dialog_1);
    var node = balloon.GetChild<Panel>(0);
    var dialogOffset = new Vector2(200, 0);
    node.Size -= dialogOffset;
    node.Position += dialogOffset;
  }
}
