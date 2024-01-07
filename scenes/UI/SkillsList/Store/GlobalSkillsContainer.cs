using Godot;
using System;
using System.Linq;

public partial class GlobalSkillsContainer : Node
{
  override public void _Ready()
  {
    SkillListGlobal.instance.GameRunRestarted += OnGameRunRestarted;
  }

  void OnGameRunRestarted()
  {
    GetChildren().ToList().ForEach(child => child.QueueFree());
  }
}
