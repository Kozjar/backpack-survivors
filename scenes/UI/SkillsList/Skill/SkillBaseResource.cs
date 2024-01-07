using Godot;
using System;

public partial class SkillBaseResource : Resource, IWeighted
{
  [Export] public string Name { get; set; }
  [Export(PropertyHint.MultilineText)] public string Description { get; set; }
  [Export] public Texture2D icon;
  [Export] public SkillRarity skillRarity = SkillRarity.Common;
  public int Weight
  {
    get
    {
      switch (skillRarity)
      {
        case SkillRarity.Common: return 5000;
        case SkillRarity.Rare: return 1000;
        case SkillRarity.Mythic: return 500;
        case SkillRarity.Legendary: return 100;
        default: return 5000;
      }
    }
  }
}