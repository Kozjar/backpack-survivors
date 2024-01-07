using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SkillListGlobal : Node
{

  public static SkillListGlobal instance;

  [Signal] public delegate void DragStartedEventHandler(SkillData skillData);
  [Signal] public delegate void DragEndedEventHandler();
  [Signal] public delegate void AttackCreatedEventHandler(Attack attack);
  [Signal] public delegate void GameRunRestartedEventHandler();
  public Node projectilesContainer;
  public Player player;
  public static int gameTime = 60 * 2;

  Texture2D red;
  Texture2D emma;
  TextureRect characterNode;

  public static Vector2 screenSize = new Vector2(1280, 720);

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

  public void OnAttack(Attack attack)
  {
    EmitSignal(SignalName.AttackCreated, attack);
  }

  public override void _Ready()
  {
    base._Ready();
    instance = this;
    projectilesContainer = GetTree().Root.GetNode("root/Elements/Projectiles");
    player = GetTree().Root.GetNode<Player>("root/Elements/Player");
    characterNode = GetTree().Root.GetNode<TextureRect>("root/UIContainer/Character");

    ProcessMode = ProcessModeEnum.Always;

    red = ResourceLoader.Load<Texture2D>("res://assets/characters/FullStanding/Red_1.png");
    emma = ResourceLoader.Load<Texture2D>("res://assets/characters/FullStanding/Science_1.png");
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

  public static Vector2 GetPlayerDirection(Vector2 position)
  {
    return -instance.player.GlobalPosition.DirectionTo(position);
  }

  public static Vector2 GetPlayerLookAt(Vector2 position)
  {
    return -instance.player.GlobalPosition.DirectionTo(position) + position;
  }

  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("pauseWholeGame"))
    {
      ToggleGameplay();
    }
  }


  public static string GetTypeText(SkillBaseResource skillResource)
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

  public Node GameNode => GetTree().Root.GetNode("root/Elements");

  public void ToggleGameplay()
  {
    SetGameState(!GameNode.GetTree().Paused);
  }

  public void SetGameState(bool paused)
  {
    if (paused)
    {
      PauseGameplay();
    }
    else
    {
      ResumeGameplay();
    }
  }

  public void PauseGameplay()
  {
    GetTree().Paused = true;
  }

  public void ResumeGameplay()
  {
    GetTree().Paused = false;
  }

  public void ShowSkillMenu()
  {
    GD.Print("showing skill menu");
  }

  public void ShowCharacter(string characterName)
  {
    characterNode.Visible = true;
    characterNode.Texture = GetCharacterTexture(characterName);
  }

  public void HideCharacter()
  {
    characterNode.Visible = false;
  }

  Texture2D GetCharacterTexture(string characterName)
  {
    switch (characterName)
    {
      case "red": return red;
      case "emma": return emma;
      default: return null;
    }
  }

  public static T RandomWeighted<T>(List<T> list) where T : IWeighted
  {
    if (list.Count == 0) return default(T);
    var totalWeight = list.Sum((skill) => skill.Weight);
    var seedWeight = GD.Randi() % totalWeight;

    int tmpWeight = 0;

    return list.Find((skill) =>
    {
      tmpWeight += skill.Weight;

      return tmpWeight > seedWeight;
    });
  }
}
