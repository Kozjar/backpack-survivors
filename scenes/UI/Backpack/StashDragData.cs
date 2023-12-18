using Godot;

public partial class StashDragData : GodotObject
{
  public StashDragData(StashCell stashCell, ItemDragPreview preview, BackpackGridItem gridItem): base()
  {
    StashCell = stashCell;
    Preview = preview;
    GridItem = gridItem;
  }

  public StashCell StashCell { get; init; }
  public ItemDragPreview Preview { get; init; }
  public BackpackGridItem GridItem { get; init; }
}
