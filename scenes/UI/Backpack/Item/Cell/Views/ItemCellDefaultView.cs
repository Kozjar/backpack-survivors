using Godot;
using System;

public partial class ItemCellDefaultView : Control
{
  [Export] public ItemCellData cellData;
  public ItemCellData originalCell;
  public Vector2 Center => Constants.cellSize * Vector2.One / 2;
  public Vector2 GlobalCenter => GlobalPosition;

  public override void _Ready()
  {
  }

  public override void _Process(double delta)
  {
    // GD.Print(Rotation);
  }

  public void MigrateBackpackCell()
  {
    originalCell.BackpackCell = cellData.BackpackCell;
  }

  public virtual void Init(BackpackItemData originItem, ItemCellData originalCell)
  {
    this.originalCell = originalCell;
    cellData = new ItemCellData();
    cellData.originItem = originItem;
    AddChild(cellData);
  }
}
