using System.Collections.Generic;
using Godot;

public partial class DamageReceiveComponent : Area2D
{
  [Export] StatsComponent statsComponent;
  [Export] Sprite2D sprite;
  [Export] Shader damageShader;
  [Export] PackedScene damageLabel;

  [Export] Color damageColor;
  [Export] Sprite2D labeledCharacter;
  [Export] public Node2D parent;
  ControlledShaderManager shaderManager;

  double hitEffectTime = 0.25;

  public override void _Process(double delta)
  {
    shaderManager?.Proccess(delta);
  }

  public void OnReceiveDamage(IAttack attack)
  {
    var damage = attack.EmitHit();

    if (damage != null)
    {
      statsComponent.statGroup.TakeDamage((float)damage);
      shaderManager = new ControlledShaderManager(sprite, "progress", hitEffectTime, damageShader);

      var label = damageLabel.Instantiate<DamageLabel>();
      GetTree().Root.GetNode("root/EffectsLabelsContainer").AddChild(label);
      label.Initialize((float)damage, labeledCharacter, damageColor);
    }
  }
}
