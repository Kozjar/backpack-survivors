using Godot;
using System;
using System.Linq;

public partial class SkillListGlobal : Autoload<SkillListGlobal>
{
  [Signal] public delegate void DragStartedEventHandler(SkillData skillData);
  [Signal] public delegate void DragEndedEventHandler();
  public Node projectilesContainer;
  public Node2D player;
  public static float gameTime = 60 * 1;

  private SkillData draggedSkill;
  public SkillData DraggedSkill
  {
    get { return draggedSkill; }
    set
    {
      draggedSkill = value;
      if (value == null)
      {
        EmitSignal(SignalName.DragEnded);
      }
      else
      {
        EmitSignal(SignalName.DragStarted, value);
      }
    }
  }

  public override void _Ready()
  {
    base._Ready();
    projectilesContainer = GetTree().Root.GetNode("root/Elements/Projectiles");
    player = GetTree().Root.GetNode<Node2D>("root/Elements/Player");

    ProcessMode = ProcessModeEnum.Always;
  }

  public Vector2 ClosestEnemyDirection
  {
    get
    {
      var enemies = GetTree().GetNodesInGroup("enemies").OfType<Node2D>();
      var closestEnemy = enemies.MinBy(enemy => player.GlobalPosition.DistanceTo(enemy.GlobalPosition));

      return closestEnemy == null ? Vector2.Right : closestEnemy.GlobalPosition.DirectionTo(player.GlobalPosition);
    }
  }

  public Vector2 GetClosestEnemy(Node2D origin, Node2D except)
  {
    var enemies = GetTree().GetNodesInGroup("enemies").OfType<Node2D>();
    var closestEnemy = enemies.MinBy(enemy => enemy == except ? 10000f : origin.GlobalPosition.DistanceTo(enemy.GlobalPosition));

    return closestEnemy == null ? Vector2.Right : closestEnemy.GlobalPosition.DirectionTo(origin.GlobalPosition);
  }

  public Vector2 GetClosestEnemy(Node2D except)
  {
    return GetClosestEnemy(player, except);
  }

  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("pauseWholeGame"))
    {
      ToggleGameplay();
    }
  }


  public static string GetTypeText(SkillResource skillResource)
  {
    if (skillResource is TriggerResource)
    {
      return "Триггер";
    }

    if (skillResource is AttackResource)
    {
      return "Атака";
    }

    return "Другое";
  }

  public void ToggleGameplay()
  {
    var node = GetTree().Root.GetNode("root").GetTree();
    node.Paused = !node.Paused;
  }
}
