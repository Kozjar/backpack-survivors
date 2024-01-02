using Godot;
using System;
using System.Collections.Generic;

public partial class SupportHighlighter : Highlighter
{
  public override void Highlight(ItemCellData[] cells)
  {
    var supportedItems = new HashSet<BackpackItemData>();

    foreach (var cell in cells)
    {
      if (cell.BackpackCell == null)
      {
        continue;
      }

      var supportedItemCells = cell.BackpackCell.ItemCellsWithModifier<BodyModifier>();
      var supportedItem = supportedItemCells.Length > 0 ? supportedItemCells[0].originItem : null;
      if (supportedItem != null && !supportedItems.Contains(supportedItem) && supportedItem != cell.originItem)
      {
        supportedItems.Add(supportedItem);
        cell.BackpackCell.SetCellStatus(BackpackCellStatus.Warning);
      }
    }

    return;
  }
}
