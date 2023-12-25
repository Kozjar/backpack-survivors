using Godot;
using System;
using System.Linq;

public partial class BackpackDragDetector : Control
{
  [Export] Control cellsContainer;
  BackpackCell[] cells;

  int col = 5;

  ItemDragPreview draggedItem => BackpackSignals.draggedItem;
  ItemCellsRepresenter[] RepresentersToDetect => draggedItem?.representers.ToArray();

  public override void _Ready()
  {
    cells = cellsContainer.GetChildren().OfType<BackpackCell>().ToArray();
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
    foreach (var representer in RepresentersToDetect)
    {
      var views = representer.CellViews;
      foreach (var view in views)
      {
        var backPackCell = DetectCellByRepresentation(view);
        HandleDetectedCell(view.cellData, backPackCell);
      }

      var cellsData = views.Select(view => view.cellData).ToArray();
      representer.highlighter?.Highlight(cellsData);
    }
  }

  BackpackCell DetectCellByRepresentation(ItemCellDefaultView cellView)
  {
    var rotatedPivot = cellView.Center.Rotated(draggedItem.content.Rotation);
    return CellAtPosition(cellView.GlobalPosition + rotatedPivot);
  }

  void HandleDetectedCell(ItemCellData itemCell, BackpackCell backpackCell)
  {
    itemCell.BackpackCell = backpackCell;
  }

  public void ClearCellsHover()
  {
    foreach (var cell in cells)
    {
      cell.ResetStyles();
    }
  }

  public Vector2I IndexAtPosition(Vector2 position)
  {
    var localPosition = position - cellsContainer.GlobalPosition;

    return (Vector2I)(localPosition / Constants.cellSize).Floor();
  }

  public BackpackCell CellAtIndex(Vector2I index)
  {
    var isInside = index.Y >= 0 && index.Y < col && index.X >= 0 && index.X < col;
    return isInside ? cells[index.Y * col + index.X] : null;
  }

  public BackpackCell CellAtPosition(Vector2 position)
  {
    return CellAtIndex(IndexAtPosition(position));
  }
}
