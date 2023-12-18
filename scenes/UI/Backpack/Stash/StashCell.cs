using Godot;
using System;
using System.Linq;

public partial class StashCell : Panel
{
  [Export] public BackpackItemData data;
  [Export] TextureRect textureRect;
  public Control itemsContainer;

  public override void _Ready()
  {
    data.Size = Size;
    textureRect.Texture = data.texture;
    itemsContainer = GetTree().Root.GetNode<Control>("root/UIContainer/BackpackInventory");
  }

  public override Variant _GetDragData(Vector2 atPosition)
  {
    var draggable = data.draggableItemScene.Instantiate<ItemDragPreview>();
    draggable.Initialize(data.texture, data);
    draggable.TreeExited += () =>
    {
      SetOtherItemsDragEnabled(true);
    };

    SetDragPreview(draggable);
    SetOtherItemsDragEnabled(false);

    return new StashDragData(this, draggable, null);
  }

  private void SetOtherItemsDragEnabled(bool enabled)
  {
    var otherGridItems = itemsContainer.GetChildren().OfType<BackpackGridItem>();

    foreach (var item in otherGridItems)
    {
      item.SetDragEnabled(enabled);
    }
  }
}
