using Godot;
using System.Linq;
using System;

public partial class AttackComponent : Node
{
  [Export] public PackedScene attackScene;
  [Export] public Node2D character;
  Node2D container;
  [Export] public StatsComponent statsComponent;
  [Export] public Timer timer;

  public override void _Ready()
  {
    container = GetTree().Root.GetNode<Node2D>("root/Elements/Projectiles");
  }

  public Vector2? ClosestEnemyDirection
  {
    get
    {
      var enemies = GetTree().GetNodesInGroup("enemies").OfType<Node2D>();
      var closestEnemy = enemies.MinBy(enemy => character.GlobalPosition.DistanceTo(enemy.GlobalPosition));

      return closestEnemy == null ? null : closestEnemy.GlobalPosition.DirectionTo(character.GlobalPosition);
    }
  }

  public void OnAttack()
  {
    if (ClosestEnemyDirection != null)
    {
      InstantiateAttack();
    }
  }

  public void InstantiateAttack()
  {
    var Attack = attackScene.Instantiate<Attack>();
    Attack.LookAt(-ClosestEnemyDirection.Value);
    Attack.Position = character.GlobalPosition;
    Attack.attackStatGroup = new AttackStatGroup(statsComponent.statGroup);

    container.AddChild(Attack);
  }
}
