using Godot;
using System;

public partial class Cutscene : Node
{
  [Signal] public delegate void FinishedEventHandler();
}

