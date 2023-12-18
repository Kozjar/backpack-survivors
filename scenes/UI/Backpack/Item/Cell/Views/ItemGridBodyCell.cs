using Godot;
using System;

public partial class ItemGridBodyCell : ItemCellDefaultView
{
  [Export] public BackpackGridItem item;

  public override Variant _GetDragData(Vector2 atPosition)
  {
    return item.StartDragging();
  }
}
