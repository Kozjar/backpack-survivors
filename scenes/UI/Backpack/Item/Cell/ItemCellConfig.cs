using Godot;
using System;

public partial class ItemCellConfig : Node
{
  [Export] public Vector2I index;
  [Export] public PackedScene view;
  [Export] public ItemCellData data;

  public Vector2 localPosition => index * Constants.cellSize;
  public Vector2 detectionPosition => localPosition + Vector2.One * Constants.cellSize / 2;

  public override void _Ready()
  {
    data.BackpackCellChanged += OnBackpackCellAssigned;
  }

  void OnBackpackCellAssigned(BackpackCell backpackCell, BackpackCell previous) {
    previous?.itemCells.Remove(data);
    backpackCell?.itemCells.Add(data);
  }
}
