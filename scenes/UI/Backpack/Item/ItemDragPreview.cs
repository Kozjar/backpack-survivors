using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ItemDragPreview : Control
{
  [Export] PackedScene cellsRepresenterScene;
  [Export] public TextureRect textureNode;
  [Export] public Control content;
  public List<ItemCellsRepresenter> representers = new();
  public BackpackItemData data;

  public ItemCellDefaultView[] CellViews => representers.SelectMany(representer => representer.CellViews).ToArray();

  public override void _Ready()
  {
    BuildRepresenters();
    BackpackSignals.draggedItem = this;
  }

  public bool CanDrop()
  {
    foreach (var representer in representers)
    {
      if (!representer.modifier.CanDrop(representer.CellViews.Select(view => view.cellData).ToArray()))
      {
        return false;
      }
    }

    return true;
  }

  void BuildRepresenters()
  {
    foreach (var modifier in data.modifiers)
    {
      if (modifier.highlighter != null)
      {
        var representer = cellsRepresenterScene.Instantiate<ItemCellsRepresenter>();
        representer.Init(modifier, modifier.highlighter);
        content.AddChild(representer);

        representers.Add(representer);
      }
    }
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
    var originCell = CellViews.OfType<ItemCellDefaultView>().First();

    return content.GlobalPosition - originCell.Position;
  }

  public override void _Input(InputEvent @event)
  {
    if (@event.IsActionPressed("rotate"))
    {
      content.Rotation += Godot.Mathf.Pi / 2;
    }
  }

  public void MigrateBackpackCells()
  {
    foreach (var cell in CellViews)
    {
      cell.MigrateBackpackCell();
    }
  }
}
