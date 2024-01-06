using Godot;
using System;
using System.Collections.Generic;

public partial class ChainAttack : Node
{
  [Export] public SkillsListActiveQueue activeQueue;

  public override void _Ready()
  {
    base._Ready();
  }
  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("startGame"))
    {
      RunTrigger(activeQueue.triggers.First, null);
      // ((TriggerResource)activeQueue.triggers.First.Value.skillResource).ApplyTrigger(null);
    }
  }

  void RunTrigger(LinkedListNode<Trigger> node, Attack attack)
  {
    node.Value.ApplyTrigger(attack, node);
    // node.Value.AttackCreated += (nextAttack) =>
    // {
    //   if (node.Next != null)
    //   {
    //     node.Next.Value.ApplyTrigger(nextAttack);
    //   }
    // };
  }
}
