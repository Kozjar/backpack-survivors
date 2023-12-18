using Godot;
using System;

public partial class ItemCellConfig : Node
{
  [Export] public Vector2I index;
  [Export] public PackedScene view;
  [Export] public BackpackItemData item;

  public Cell backpackCell { get; set; }

  public Vector2 localPosition => index * Constants.cellSize;
  public Vector2 detectionPosition => localPosition + Vector2.One * Constants.cellSize / 2;

  public bool IsInside(Vector2 localPosition)
  {
    var cellPosition = localPosition - this.localPosition;

    return cellPosition.X >= 0 && cellPosition.X < Constants.cellSize && cellPosition.Y >= 0 && cellPosition.Y < Constants.cellSize;
  }
}
