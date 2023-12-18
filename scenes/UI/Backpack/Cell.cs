using Godot;
using System;

public partial class Cell : MarginContainer
{
  [Export] StyleBox successStyle;
  [Export] StyleBox warningStyle;
  [Export] StyleBox overlapStyle;
  StyleBox defaultStyle;
  [Export] Panel panel;
  public BackpackItemData item;
  private ItemCellConfig cellCandidate;

  public ItemCellConfig CellCandidate
  {
    get => cellCandidate;
    set
    {
      cellCandidate = value;

      if (cellCandidate != null)
      {
        if (cellCandidate is ItemCellMain)
        {
          OnItemCellOverlap((ItemCellMain)cellCandidate);
        }
      }
      else
      {
        SetCellStatus(BackpackCellStatus.Default);
      }
    }
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

  public void OnItemCellOverlap(ItemCellMain cellCandidate)
  {
    if (item != null && cellCandidate.item != item)
    {
      SetCellStatus(BackpackCellStatus.Overlap);
      return;
    }

    SetCellStatus(BackpackCellStatus.Success);
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
