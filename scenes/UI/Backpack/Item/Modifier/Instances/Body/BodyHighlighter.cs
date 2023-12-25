using Godot;
using System;

public partial class BodyHighlighter : Highlighter
{
  public override void Highlight(ItemCellData[] cells)
  {
    foreach (var cell in cells)
    {
      if (cell.BackpackCell != null)
      {
        var existedItemCell = cell.BackpackCell.GetItemCell(cell.originItem);
        if (existedItemCell != null && existedItemCell.HasModifier<BodyModifier>())
        {
          cell.BackpackCell.SetCellStatus(BackpackCellStatus.Success);
        }

        if (cell.BackpackCell.ContainsModifier<BodyModifier>())
        {
          cell.BackpackCell.SetCellStatus(BackpackCellStatus.Overlap);
        }

        cell.BackpackCell.SetCellStatus(BackpackCellStatus.Success);
      }
    }
  }
}
