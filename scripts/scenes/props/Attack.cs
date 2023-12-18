using Godot;
using System;

public partial class Attack : Area2D, IAttack
{
	[Export] public Node2D shape;
	ControlledShaderManager shaderManager;
	public AttackStatGroup attackStatGroup;

	public override void _Process(double delta)
	{
		// shaderManager.Proccess(delta);
	}

	public float? EmitHit()
	{
		return attackStatGroup.EmitHit();
	}

  public void DealDamage(Area2D damageReceiver)
  {
    ((DamageReceiveComponent)damageReceiver).OnReceiveDamage(this);
  }
}
