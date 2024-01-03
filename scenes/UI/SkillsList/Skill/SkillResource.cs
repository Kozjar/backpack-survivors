using Godot;
using System;

public partial class SkillResource : Resource
{
  [Export] public string Name { get; set; }
  [Export(PropertyHint.MultilineText)] public string Description { get; set; }
  [Export] public PackedScene inventoryScene;
  [Export] public PackedScene dragScene = ResourceLoader.Load<PackedScene>("res://scenes/UI/SkillsList/SkillView/SkillDragPreview.tscn");
}
