using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{
  [Export] State initialState;
  State currentState;
  Dictionary<string, State> stateList = new();

  public override void _Ready()
  {
    base._Ready();
    foreach (Node child in GetChildren())
    {
      if (child is State state)
      {
        stateList.Add(state.name, state);
        state.stateMachine = this;
      }
    }
    TransitionTo(initialState.name);
  }

  public override void _Process(double delta)
  {
    base._Process(delta);
    currentState?.Update();
  }

  public override void _PhysicsProcess(double delta)
  {
    base._PhysicsProcess(delta);
    currentState?.PhysicsUpdate(delta);
  }

  public void TransitionTo(string name, params Variant[] args)
  {
    currentState?.Exit();
    var newState = stateList[name];
    newState.Enter(args);
    currentState = newState;
  }
}
