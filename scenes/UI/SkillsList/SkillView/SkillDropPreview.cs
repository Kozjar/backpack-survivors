using Godot;
using System;

public partial class SkillDropPreview : PanelContainer
{
  [Signal] public delegate void skillDroppedEventHandler();
  [Export] public Control childComponents;

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
  }

  public void ShowDropPreview()
  {
    childComponents.Visible = false;
    Visible = true;
  }

  public void HideDropPreview()
  {
    childComponents.Visible = true;
    Visible = false;
  }
}
