using Godot;
using System;

public partial class Stash : PanelContainer
{
  [Export] PackedScene cellScene;
  [Export] Control cellContainer;

  public override void _Ready()
  {
    BackpackSignals.stash = this;
  }

  public void AddItem(BackpackItemData data) {
    var cell = cellScene.Instantiate<StashCell>();
    data.Reparent(cell);
    cell.data = data;

    cellContainer.AddChild(cell);
  }

  public override bool _CanDropData(Vector2 atPosition, Variant data)
  {
    return ((StashDragData)data).StashCell == null;
  }

  public override void _DropData(Vector2 atPosition, Variant data)
  {
    var daragData = (StashDragData)data;

    if (daragData.StashCell != null) {
      return;
    }

    if (daragData.GridItem != null) {
      AddItem(daragData.GridItem.data);
      BackpackSignals.instance.EmitSignal(BackpackSignals.SignalName.BackpackItemRemoved, daragData.GridItem.data);
    }
  }

  // public void AddItem(BackpackItemData data) {

  // }
}
