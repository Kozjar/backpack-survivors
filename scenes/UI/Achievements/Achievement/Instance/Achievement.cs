using Godot;
using System;

public partial class Achievement : Node
{
  [Export] public string name;
  [Export(PropertyHint.MultilineText)] public string condition;
  [Export(PropertyHint.MultilineText)] public string reward;
  [Export] public Texture2D icon;

  public bool enabled = false;
  public bool markCompleted = false;

  protected bool ShouldValidate => !(enabled || markCompleted);

  public virtual string NameText => name;
  public virtual string Condition => condition;
  public virtual string Reward => reward;

  public virtual void GrantReward()
  {
    enabled = true;
  }
}
