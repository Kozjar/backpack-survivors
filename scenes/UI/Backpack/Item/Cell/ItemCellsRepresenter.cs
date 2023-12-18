using Godot;
using System;

public partial class ItemCellsRepresenter : Control
{
  public Func<ItemCellConfig, ItemCellDefaultView> rendererOverride;
  private ItemCellConfig[] cellsConfig;
  public ItemCellConfig[] CellsConfig
  {
    get => cellsConfig;
    set
    {
      cellsConfig = value;
      DisplayCells();
    }
  }

  public override void _Ready()
  {
    // DisplayCells();
  }

  void DisplayCells()
  {
    foreach (var cell in CellsConfig)
    {
      var scene = InstantiateCell(cell);
      scene.PivotOffset = scene.Center;
      scene.cell = cell;
      scene.CustomMinimumSize = Vector2.One * Constants.cellSize;
      scene.Position = cell.localPosition;

      AddChild(scene);
    }
  }

  ItemCellDefaultView InstantiateCell(ItemCellConfig cell)
  {
    if (rendererOverride != null)
    {
      return rendererOverride(cell);
    }

    return cell.view == null ? new ItemCellDefaultView() : cell.view.Instantiate<ItemCellDefaultView>();
  }
}
