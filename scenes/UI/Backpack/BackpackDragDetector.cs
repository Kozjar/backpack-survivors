using Godot;
using System;
using System.Linq;

public partial class BackpackDragDetector : Control
{
  [Export] Control cellsContainer;
  Cell[] cells;

  int col = 5;

  ItemDragPreview draggedItem => BackpackSignals.draggedItem;

  public override void _Ready()
  {
    cells = cellsContainer.GetChildren().OfType<Cell>().ToArray();
  }

  public override void _Process(double delta)
  {
    ClearCellsHover();
    if (draggedItem != null)
    {
      RunDetection();
    }
  }

  void RunDetection()
  {
    foreach (var representation in draggedItem.cellsRepresenter.GetChildren().OfType<ItemCellDefaultView>())
    {
      var backPackCell = DetectCellByRepresentation(representation);
      HandleDetectedCell(representation.cell, backPackCell);
    }
  }

  Cell DetectCellByRepresentation(ItemCellDefaultView cellRepresentation) {
    var rotatedPivot = cellRepresentation.Center.Rotated(draggedItem.content.Rotation);
    return CellAtPosition(cellRepresentation.GlobalPosition + rotatedPivot);
  }

  void DetectCell(ItemCellConfig cell, ItemCellConfig initialCell, Vector2I initialIndex)
  {
    if (initialCell == null)
    {
      cell.backpackCell = null;
      return;
    }

    var cellRelativeIndex = cell.index - initialCell.index;
    cell.backpackCell = CellAtIndex(initialIndex + cellRelativeIndex);

    if (cell.backpackCell != null)
    {
      cell.backpackCell.CellCandidate = cell;
    }
  }

  void HandleDetectedCell(ItemCellConfig itemCell, Cell backpackCell) {
    if (itemCell == null)
    {
      itemCell.backpackCell = null;
      return;
    }

    itemCell.backpackCell = backpackCell;

    if (backpackCell != null && itemCell is ItemCellMain)
    {
      backpackCell.CellCandidate = itemCell;
    }
  }

  public void ClearCellsHover(bool clearItemCells = true)
  {
    foreach (var cell in cells)
    {
      if (cell.CellCandidate != null)
      {
        if (clearItemCells)
        {
          cell.CellCandidate.backpackCell = null;
        }
        cell.CellCandidate = null;
      }
    }
  }

  public Vector2I IndexAtPosition(Vector2 position)
  {
    var localPosition = position - cellsContainer.GlobalPosition;

    return (Vector2I)(localPosition / Constants.cellSize).Floor();
  }

  public Cell CellAtIndex(Vector2I index)
  {
    var isInside = index.Y >= 0 && index.Y < col && index.X >= 0 && index.X < col;
    return isInside ? cells[index.Y * col + index.X] : null;
  }

  public Cell CellAtPosition(Vector2 position)
  {
    return CellAtIndex(IndexAtPosition(position));
  }

  ItemCellConfig DetectInitialCell(ref Vector2I index)
  {
    foreach (var cell in draggedItem.data.cells)
    {
      var _index = IndexAtPosition(draggedItem.content.GlobalPosition + cell.detectionPosition);

      if (CellAtIndex(_index) != null)
      {
        index = _index;
        return cell;
      }
    }

    return null;
  }
}
