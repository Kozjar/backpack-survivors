using Godot;
using System;

public partial class SkillListGlobal : Autoload<SkillListGlobal>
{
  [Signal] public delegate void DragStartedEventHandler();
  [Signal] public delegate void DragEndedEventHandler();
}
