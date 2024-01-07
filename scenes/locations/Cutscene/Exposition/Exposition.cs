using DialogueManagerRuntime;
using Godot;
using System;

public partial class Exposition : DialogCutscene
{
  [Export] Resource dialog;

  public override void _Ready()
  {
    base._Ready();
    ShowDialog(dialog);
  }
}
