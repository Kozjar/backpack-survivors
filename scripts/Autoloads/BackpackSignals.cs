using Godot;
using System;

public partial class BackpackSignals : Autoload<BackpackSignals>
{
  public static ItemDragPreview draggedItem;
  public static Stash stash;

  [Signal] public delegate void BackpackItemRemovedEventHandler(BackpackItemData data);
  [Signal] public delegate void CellDetectedEventHandler(ItemCellConfig itemCell);

  
  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("pauseWholeGame"))
    {
      GetTree().Paused = !GetTree().Paused;
    }
  }
}
