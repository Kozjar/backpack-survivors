using Godot;
using System;

public partial class State : Node, IWeighted
{
  [Export] public string name;
  [Export] public int Weight { get; set; }
  public StateMachine stateMachine;

  public virtual void Update() { }
  public virtual void PhysicsUpdate(double delta) { }
  public virtual void Enter(params Variant[] args) { }
  public virtual void Exit() { }
}
