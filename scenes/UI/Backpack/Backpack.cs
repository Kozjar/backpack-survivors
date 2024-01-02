using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Backpack : PanelContainer
{
  [Export] Control itemsContainer;
  [Export] Control cellsContainer;
  [Export] Stash stash;
  [Export] BackpackDragDetector dragDetector;
  List<BackpackCell> cells;

  int col = 5;


  public List<BackpackGridItem> OtherGridItems => itemsContainer.GetChildren().OfType<BackpackGridItem>().ToList();

  public override void _Ready()
  {
    cells = cellsContainer.GetChildren().OfType<BackpackCell>().ToList();
    BackpackSignals.instance.BackpackItemRemoved += RemoveItem;
    SetCellsIndex(cells.ToArray());
  }

  void SetCellsIndex(BackpackCell[] cells)
  {
    for (int i = 0; i < cells.Length; i++)
    {
      cells[i].index = i;
    }
  }

  public override bool _CanDropData(Vector2 atPosition, Variant data)
  {
    var dragData = (StashDragData)data;

    return dragData.Preview.CanDrop();
  }

  public override void _DropData(Vector2 atPosition, Variant data)
  {
    var dragData = (StashDragData)data;
    var itemData = dragData.Preview.data;
    var gridItem = dragData.GridItem;

    var itemBodyCells = Array.Find(dragData.Preview.data.modifiers, modifier => modifier is BodyModifier)?.cellConfigs;

    if (dragData.StashCell != null)
    {
      gridItem = CreateGridItemFromStash(dragData.Preview);
      itemsContainer.AddChild(gridItem);
      dragData.StashCell.QueueFree();
    }

    if (dragData.GridItem != null)
    {
      ClearGridItemCells(dragData.GridItem.data);
      itemData.EmitSignal(BackpackItemData.SignalName.RemovedFromBackpack);
    }

    itemData.EmitSignal(BackpackItemData.SignalName.AddedToBackpack);
    SnapItemToGrid(gridItem, dragData.Preview);
    dragData.Preview.MigrateBackpackCells();
    // UpdateCellsData(itemBodyCells, itemData);
  }

  void HandleItemBody(ItemDragPreview preview)
  {
    // var itemBodyCells = Array.Find(preview.data.modifiers, modifier => modifier is BodyModifier);
    // var backpackCells = itemBodyCells.Select(cell => cell.data.BackpackCell);

    // PushToStashOverlappedItems(itemBodyCells, preview.data);
  }

  // private void PushToStashOverlappedItems(List<BackpackCell> cells, BackpackItemData whitelistItem)
  // {
  //   var uniqueItems = new List<BackpackItemData>();
  //   cells.ForEach(cell =>
  //   {
  //     if (cell.Item != null && !uniqueItems.Contains(cell.Item) && cell.Item != whitelistItem)
  //     {
  //       uniqueItems.Add(cell.Item);
  //     }
  //   });

  //   uniqueItems.ForEach(data =>
  //   {
  //     stash.AddItem(data);
  //     RemoveItem(data);
  //   });
  // }

  private void UpdateCellsData(List<BackpackCell> cells, BackpackItemData data)
  {
    // cells.ForEach(cell => cell.Item = data);
  }

  private void ClearGridItemCells(BackpackItemData data)
  {
    cells.ForEach(cell => cell.RemoveItem(data));
  }

  public void RemoveItem(BackpackItemData data)
  {
    data.OnRemovedFromBackpack();
    GetItem(data)?.QueueFree();
    ClearGridItemCells(data);
  }

  private BackpackGridItem GetItem(BackpackItemData data)
  {
    return OtherGridItems.Find(item => item.data == data);
  }

  private BackpackGridItem CreateGridItemFromStash(ItemDragPreview preview)
  {
    var itemData = preview.data;
    var size = preview.textureNode.Size;
    var gridItem = itemData.gridItemScene.Instantiate<BackpackGridItem>();

    gridItem.data = itemData;
    gridItem.SetTexture(itemData.texture);
    itemData.Reparent(gridItem, false);

    gridItem.CustomMinimumSize = size;
    gridItem.textureRect.CustomMinimumSize = size;

    return gridItem;
  }

  private void SnapItemToGrid(BackpackGridItem item, ItemDragPreview preview)
  {
    var localPosition = preview.content.GlobalPosition - cellsContainer.GlobalPosition;
    item.GlobalPosition = localPosition.Snapped(Vector2.One * Constants.cellSize) + cellsContainer.GlobalPosition;
    item.Rotation = preview.content.Rotation;
  }

  private void SetOtherItemsMouseFilter(MouseFilterEnum mouseFilter)
  {
    OtherGridItems.ForEach(item => { item.MouseFilter = mouseFilter; });
  }
}
