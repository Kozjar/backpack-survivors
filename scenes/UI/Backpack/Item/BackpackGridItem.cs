using Godot;
using System;
using System.Linq;

public partial class BackpackGridItem : Control
{
  [Export] public BackpackItemData data;
  [Export] public TextureRect textureRect;
  [Export] PackedScene dragCellScene;
  [Export] ItemCellsRepresenter bodyRepresenter;
  public Control itemsContainer;

  bool isMouseOver = false;
  bool isHoverBody = false;

  public override void _Ready()
  {
    itemsContainer = GetTree().Root.GetNode<Control>("root/UIContainer/BackpackInventory");
    bodyRepresenter.rendererOverride = CreateDragCell;
    bodyRepresenter.CellConfigs = data.cells.OfType<ItemCellMain>().ToArray();
  }

  ItemGridBodyCell CreateDragCell(ItemCellConfig cell)
  {
    var scene = dragCellScene.Instantiate<ItemGridBodyCell>();
    scene.item = this;

    return scene;
  }

  public void SetTexture(Texture2D texture)
  {
    textureRect.Texture = texture;
  }

  public StashDragData StartDragging()
  {
    var draggable = data.draggableItemScene.Instantiate<ItemDragPreview>();
    draggable.Initialize(data.texture, data);
    draggable.content.Rotation = Rotation;

    Visible = false;
    draggable.TreeExited += () =>
    {
      Visible = true;
      SetOtherItemsDragEnabled(true);
    };

    SetDragPreview(draggable);
    SetOtherItemsDragEnabled(false);

    return new StashDragData(null, draggable, this);
  }

  private void SetOtherItemsDragEnabled(bool enabled)
  {
    var otherGridItems = itemsContainer.GetChildren().OfType<BackpackGridItem>();

    foreach (var item in otherGridItems)
    {
      item.SetDragEnabled(enabled);
    }
  }

  public void SetDragEnabled(bool enabled)
  {
    var filter = enabled ? MouseFilterEnum.Pass : MouseFilterEnum.Ignore;

    foreach (var child in bodyRepresenter.GetChildren().OfType<ItemGridBodyCell>())
    {
      child.MouseFilter = filter;
    }
  }
}
