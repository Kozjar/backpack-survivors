using Godot;
using System;

public partial class MoreTriggerSlots : Node
{
  public override void _Ready()
  {
    base._Ready();
    SkillsListActiveQueue.instance.totalSlots += 1;
    SkillsListActiveQueue.instance.BuildEmptySlots();
  }

  public override void _ExitTree()
  {
    base._ExitTree();
    SkillsListActiveQueue.instance.totalSlots -= 1;
    SkillsListActiveQueue.instance.RemoveEmptySlot();
  }
}
