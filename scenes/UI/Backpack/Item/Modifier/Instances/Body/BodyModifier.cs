using Godot;
using System;

public partial class BodyModifier : ItemModifier
{
  public override void _Ready()
  {
    foreach (var cell in cellConfigs)
    {
      // cell
    }
  }

  void RemoveExistedBodyItems(BackpackCell backpackCell) {
    var cellsToRemove = backpackCell.ItemCellsWithModifier<BodyModifier>();

    foreach (var cell in cellsToRemove)
    {
      BackpackSignals.stash.AddItem(cell.originItem);
      BackpackSignals.instance.EmitSignal(BackpackSignals.SignalName.BackpackItemRemoved, cell.originItem);
    }
  }

  public override bool CanDrop(ItemCellData[] cellDatas)
  {
    var emptyCell = Array.Find(cellDatas, cell => cell.BackpackCell == null);

    return emptyCell == null;
  }
}
