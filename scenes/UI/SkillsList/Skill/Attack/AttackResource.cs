using Godot;
using System;

public partial class AttackResource : SkillResource
{
  [Export] public PackedScene attackScene;
  [Export] float damage;

  public Attack CreateAttack(Node Container, Vector2 position)
  {
    var attackNode = attackScene.Instantiate<Attack>();
    attackNode.GlobalPosition = position;
    attackNode.Init(new AttackStatGroup(damage, 0, 1));
    Container.AddChild(attackNode);

    return attackNode;
  }

  public override AttackSkill CreateInstance()
  {
    return new AttackSkill(this);
  }
}
