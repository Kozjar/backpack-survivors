using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ItemDragPreview : Control
{
  [Export] public TextureRect textureNode;
  [Export] public Control content;
  [Export] public ItemCellsRepresenter cellsRepresenter;
  public BackpackItemData data;

  public override void _Ready()
  {
    BackpackSignals.draggedItem = this;
    cellsRepresenter.CellsConfig = data.cells;
  }

  public override void _ExitTree()
  {
    BackpackSignals.draggedItem = null;
    base._ExitTree();
  }

  public void Initialize(Texture2D texture, BackpackItemData data)
  {
    SetTexture(texture);
    this.data = data;
    content.PivotOffset = PivotOffset;
    content.Position -= PivotOffset;
  }

  public void SetTexture(Texture2D texture)
  {
    textureNode.Texture = texture;
  }

  public Vector2 StickToGridPosition()
  {
    var originCell = cellsRepresenter.GetChildren().OfType<ItemCellDefaultView>().First();

    GD.Print(GlobalPosition, originCell.Position);

    return content.GlobalPosition - originCell.Position;
  }
  
  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("rotate"))
    {
      content.Rotation += Godot.Mathf.Pi / 2;
    }
  }
}
