using Godot;
using System;

public partial class BackpackSignals : Autoload<BackpackSignals>
{
  public static ItemDragPreview draggedItem;

  [Signal] public delegate void BackpackItemRemovedEventHandler(BackpackItemData data);
  [Signal] public delegate void CellDetectedEventHandler(ItemCellConfig itemCell);
}
