using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class IdleWithRandomExit : State
{
  [Export] public State[] nextStates;
  [Export] float duration = 1;
  List<IWeighted> weightedStates => nextStates.OfType<IWeighted>().ToList();

  override public void Enter(params Variant[] args)
  {
    GetTree().CreateTimer(duration, false).Timeout += () =>
    {
      var nextState = SkillListGlobal.RandomWeighted(weightedStates) as State;
      stateMachine.TransitionTo(nextState.name);
    };
  }
}
