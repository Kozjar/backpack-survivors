using Godot;
using System;

public partial class ItemModifier : Node
{
  [Export] public bool ignoreDetection = false;
  [Export] public ItemCellConfig[] cellConfigs;
  [Export] public PackedScene highlighter;

  public virtual bool CanDrop(ItemCellData[] cellDatas)
  {
    return true;
  }
}
