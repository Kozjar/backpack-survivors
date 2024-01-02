using Godot;
using System;
using System.Collections.Generic;

public partial class BodyModifier : ItemModifier
{
  public override void _Ready()
  {
    foreach (var cell in cellConfigs)
    {
      cell.data.BackpackCellChanged += RemoveExistedBodyItems;
    }
  }

  void RemoveExistedBodyItems(BackpackCell backpackCell, BackpackCell previous)
  {
    var cellsToRemove = backpackCell.ItemCellsWithModifier<BodyModifier>();
    var removedItems = new List<BackpackItemData>();

    foreach (var cell in cellsToRemove)
    {
      if (!removedItems.Contains(cell.originItem) && cell.originItem != itemData)
      {
        BackpackSignals.stash.AddItem(cell.originItem);
        BackpackSignals.instance.EmitSignal(BackpackSignals.SignalName.BackpackItemRemoved, cell.originItem);
        removedItems.Add(cell.originItem);
      }
    }
  }

  public override bool CanDrop(ItemCellData[] cellDatas)
  {
    var emptyCell = Array.Find(cellDatas, cell => cell.BackpackCell == null);

    return emptyCell == null;
  }
}
