using Godot;
using System;
using System.Linq;

public partial class BackpackItemData : Control
{
  [Export] public PackedScene draggableItemScene;
  [Export] public PackedScene gridItemScene;
  [Export] Node[] modifiers;
  [Export] public ItemCellConfig[] cells;
  [Export] public Texture2D texture;

  public ItemCellMain[] BodyCells => cells.OfType<ItemCellMain>().ToArray();

  public void Apply()
  {
    foreach (var modifier in modifiers)
    {
      ((IBackpackItemModifier)modifier).Apply();
    }
  }
}
