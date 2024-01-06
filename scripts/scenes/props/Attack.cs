using Godot;
using System;

public partial class Attack : Area2D, IAttack
{
  [Signal] public delegate void DamageDealtEventHandler(Node2D entity);
  ControlledShaderManager shaderManager;
  public AttackStatGroup attackStatGroup;

  // public override void _Process(double delta)
  // {
  // 	// shaderManager.Proccess(delta);
  // }

  public float? EmitHit()
  {
    return attackStatGroup.EmitHit();
  }

  public void DealDamage(Area2D damageReceiver)
  {
    EmitSignal(SignalName.DamageDealt, ((DamageReceiveComponent)damageReceiver).parent);
    ((DamageReceiveComponent)damageReceiver).OnReceiveDamage(this);
  }

  public void Init(AttackStatGroup statGroup)
  {
    attackStatGroup = statGroup;
  }
}
