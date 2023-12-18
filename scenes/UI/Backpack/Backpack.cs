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
  List<Cell> cells;

  int col = 5;


  public List<BackpackGridItem> OtherGridItems => itemsContainer.GetChildren().OfType<BackpackGridItem>().ToList();

  public override void _Ready()
  {
    cells = cellsContainer.GetChildren().OfType<Cell>().ToList();
    BackpackSignals.instance.BackpackItemRemoved += RemoveItem;
  }

  public override bool _CanDropData(Vector2 atPosition, Variant data)
  {
    var dragData = (StashDragData)data;
    var itemBodyCells = dragData.Preview.data.cells.OfType<ItemCellMain>();

    foreach (var cell in itemBodyCells)
    {
      if (cell.backpackCell == null)
      {
        return false;
      }
    }

    return true;
  }

  public override void _DropData(Vector2 atPosition, Variant data)
  {
    dragDetector.ClearCellsHover(false);

    var dragData = (StashDragData)data;
    var itemBodyCells = dragData.Preview.data.cells.OfType<ItemCellMain>().Select(cell => cell.backpackCell).ToList();
    var itemData = dragData.Preview.data;
    var gridItem = dragData.GridItem;

    PushToStashOverlappedItems(itemBodyCells, itemData);

    if (dragData.StashCell != null)
    {
      gridItem = CreateGridItemFromStash(dragData.Preview);
      itemsContainer.AddChild(gridItem);
      dragData.StashCell.QueueFree();
    }

    if (dragData.GridItem != null)
    {
      ClearGridItemCells(dragData.GridItem.data);
      dragData.GridItem.GlobalPosition = dragData.Preview.StickToGridPosition();
    }

    SnapItemToGrid(gridItem, dragData.Preview);
    UpdateCellsData(itemBodyCells, itemData);
  }

  private void PushToStashOverlappedItems(List<Cell> cells, BackpackItemData whitelistItem)
  {
    var uniqueItems = new List<BackpackItemData>();
    cells.ForEach(cell =>
    {
      if (cell.item != null && !uniqueItems.Contains(cell.item) && cell.item != whitelistItem)
      {
        uniqueItems.Add(cell.item);
      }
    });

    uniqueItems.ForEach(data =>
    {
      stash.AddItem(data);
      RemoveItem(data);
    });
  }

  private void UpdateCellsData(List<Cell> cells, BackpackItemData data)
  {
    cells.ForEach(cell => cell.item = data);
  }

  private void ClearGridItemCells(BackpackItemData data)
  {
    cells.ForEach(cell =>
    {
      if (cell.item == data)
      {
        cell.item = null;
      }
    });
  }

  public void RemoveItem(BackpackItemData data)
  {
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
