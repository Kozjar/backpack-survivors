using Godot;
using System;
using System.Collections.Generic;

public partial class BackpackCell : MarginContainer
{
  [Export] StyleBox successStyle;
  [Export] StyleBox warningStyle;
  [Export] StyleBox overlapStyle;
  StyleBox defaultStyle;
  [Export] Panel panel;
  public int index;
  private ItemCellData cellHighlight;
  public List<ItemCellData> itemCells = new();

  public ItemCellData CellHighlight
  {
    get => cellHighlight;
    set
    {
      cellHighlight = value;

      if (cellHighlight != null)
      {
        // if (cellHighlight is ItemCellMain)
        // {
        //   OnItemCellOverlap((ItemCellMain)cellHighlight);
        // }
      }
      else
      {
        SetCellStatus(BackpackCellStatus.Default);
      }
    }
  }

  public void ResetStyles() {
    SetCellStatus(BackpackCellStatus.Default);
  }

  public override void _Ready()
  {
    defaultStyle = panel.GetThemeStylebox("panel");
  }

  public void SetCellStatus(BackpackCellStatus status)
  {
    var style = GetCellStyle(status);
    if (style != null)
    {
      panel.AddThemeStyleboxOverride("panel", style);
    }
  }

  public void AddItemCell(ItemCellData itemCell){
    itemCells.Add(itemCell);
  }

  public void RemoveItemCell(ItemCellData itemCell){
    itemCells.Remove(itemCell);
  }

  public void OnItemCellOverlap(ItemCellData cellHighlight)
  {
    // var itemCell = GetItemCell(cellHighlight?.originItem);
    // var bodyItem = Getcell
    // if (Item != null && cellHighlight.cellData.originItem != Item)
    // {
    //   SetCellStatus(BackpackCellStatus.Overlap);
    //   return;
    // }

    // SetCellStatus(BackpackCellStatus.Success);
  }

  public void RemoveItem(BackpackItemData item) {
    itemCells.RemoveAll(cell => cell.originItem == item);
  }

  public bool ContainsItem(BackpackItemData item) {
    return GetItemCell(item) != null;
  }

  public ItemCellData GetItemCell(BackpackItemData item) {
    return itemCells.Find(cell => cell.originItem == item);
  }

  public ItemCellData[] ItemCellsWithModifier<T>() where T : ItemModifier
  {
    var cellsWithModifiers = new List<ItemCellData>();

    foreach (var cell in itemCells)
    {
      if (cell.HasModifier<T>())
      {
        cellsWithModifiers.Add(cell);
      }
    }
    
    return cellsWithModifiers.ToArray();
  }

  public bool ContainsModifier<T>() where T : BodyModifier {
    return itemCells.Find(cell => cell.HasModifier<T>()) != null;
  }

  private StyleBox GetCellStyle(BackpackCellStatus status)
  {
    switch (status)
    {
      case BackpackCellStatus.Success: return successStyle;
      case BackpackCellStatus.Warning: return warningStyle;
      case BackpackCellStatus.Overlap: return overlapStyle;
      case BackpackCellStatus.Default: return defaultStyle;
      default: return null;
    }
  }
}
