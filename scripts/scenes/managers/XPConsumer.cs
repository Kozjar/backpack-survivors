using Godot;
using System;

public partial class XPConsumer : Area2D
{
  [Signal] public delegate void XpChangedEventHandler(float xp);
  [Signal] public delegate void LevelUpEventHandler(int level, float maxXp);
  readonly int fisrstLevelRequirement;
  [Export] public int xpRequired = 4;
  float _currentXp;
  public int level = 1;

  int NextLevelXp => (int)Math.Round(fisrstLevelRequirement + (level - 1) * fisrstLevelRequirement * 0.5f);
  public float currentXp
  {
    get => _currentXp;
    set
    {
      _currentXp = value;
      EmitSignal("XpChanged", value);
      ValidateXpAmount();
    }
  }

  public XPConsumer()
  {
    fisrstLevelRequirement = xpRequired;
  }

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    // EmitSignal("LevelUp", level, xpRequired);
    // EmitSignal("XpChanged", currentXp);
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(double delta)
  {
  }

  public void OnXPCatch(Area2D area)
  {
    if (area is Experience xp)
    {
      currentXp += xp.amount;
      xp.QueueFree();
    }
  }

  void ValidateXpAmount()
  {
    if (currentXp >= xpRequired)
    {
      var xpOverflow = currentXp - xpRequired;
      level += 1;
      xpRequired = NextLevelXp;
      EmitSignal("LevelUp", level, xpRequired);
      currentXp = xpOverflow;
    }
  }
}
