using Godot;
using System;

public partial class DashPrepare : State
{
  [Export] float dashDistance;
  [Export] Node2D lineContainer;
  Line2D line;
  Vector2 direction;
  bool lookAtPlayer = true;

  public override void Enter(params Variant[] args)
  {
    base.Enter(args);
    lookAtPlayer = true;
    line = new Line2D();
    lineContainer.AddChild(line);
    Vector2[] points = new Vector2[] { Vector2.Zero, Vector2.Right * dashDistance };
    line.Points = points;
    line.Width = 60;
    line.DefaultColor = new Color("ff505740");

    GetTree().CreateTimer(3f).Timeout += LockTarget;
  }

  public override void Update()
  {
    base.Update();
    if (lookAtPlayer)
    {
      direction = SkillListGlobal.GetPlayerLookAt(line.GlobalPosition);
      line.LookAt(direction);
    }
  }

  void LockTarget()
  {
    lookAtPlayer = false;
    GetTree().CreateTimer(0.5f).Timeout += () => stateMachine.TransitionTo("dash", direction - line.GlobalPosition, dashDistance);
  }

  public override void Exit()
  {
    base.Exit();
    line.QueueFree();
    line = null;
  }
}
