using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ItemCellsRepresenter : Control
{
  public Func<ItemCellConfig, ItemCellDefaultView> rendererOverride;
  public Highlighter highlighter;
  public ItemModifier modifier;
  private ItemCellConfig[] cellsConfig;
  public ItemCellConfig[] CellConfigs
  {
    get => cellsConfig;
    set
    {
      cellsConfig = value;
      DisplayCells();
    }
  }

  List<ItemCellDefaultView> cellViews = new();
  public ItemCellDefaultView[] CellViews => GetChildren().OfType<ItemCellDefaultView>().ToArray();

  public override void _Ready()
  {
    // DisplayCells();
  }

  public void Init(ItemModifier modifier, PackedScene highlighterScene = null)
  {
    if (highlighterScene != null)
    {
      highlighter = highlighterScene.Instantiate<Highlighter>();
      AddChild(highlighter);
    }

    CellConfigs = modifier.cellConfigs;
    this.modifier = modifier;
  }

  void DisplayCells()
  {
    foreach (var cell in CellConfigs)
    {
      var scene = InstantiateCell(cell);
      scene.Init(cell.data.originItem, cell.data);
      scene.PivotOffset = scene.Center;
      scene.CustomMinimumSize = Vector2.One * Constants.cellSize;
      scene.Position = cell.localPosition;
      cellViews.Add(scene);

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
