using DialogueManagerRuntime;
using Godot;
using System;

public partial class Departure : DialogCutscene
{
  [Export] Resource dialog;

  public override void _Ready()
  {
    base._Ready();
    ShowDialog(dialog);
  }
}
