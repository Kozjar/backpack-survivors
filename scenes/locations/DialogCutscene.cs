using DialogueManagerRuntime;
using Godot;
using System;

public partial class DialogCutscene : Cutscene
{
  Resource currentDialog;

  public override void _Ready()
  {
    base._Ready();
  }

  void OnDialogueEnded(Resource resource)
  {
    GD.Print($"dialog ended {resource}");
    if (resource == currentDialog)
    {
      EmitSignal(SignalName.Finished);
    }
  }

  public CanvasLayer ShowDialog(Resource dialog)
  {
    currentDialog = dialog;
    var balloon = DialogueManager.ShowExampleDialogueBalloon(dialog);
    DialogueManager.DialogueEnded += OnDialogueEnded;
    TreeExited += () =>
    {
      DialogueManager.DialogueEnded -= OnDialogueEnded;
    };

    return balloon;
  }
}
