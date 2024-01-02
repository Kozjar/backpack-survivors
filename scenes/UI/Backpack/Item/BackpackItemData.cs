using Godot;
using System;
using System.Linq;

public partial class BackpackItemData : Control
{
  [Export] public PackedScene draggableItemScene;
  [Export] public PackedScene gridItemScene;
  [Export] public ItemModifier[] modifiers;
  [Export] public ItemCellConfig[] cells;
  [Export] public Texture2D texture;

  [Signal] public delegate void AddedToBackpackEventHandler();
  [Signal] public delegate void RemovedFromBackpackEventHandler();

  public override void _Ready()
  {
    SetCellsData();
  }

  void SetCellsData()
  {
    foreach (var cell in cells)
    {
      cell.data.originItem = this;
    }
  }

  public void OnRemovedFromBackpack()
  {
    EmitSignal(SignalName.RemovedFromBackpack);
    ClearBackpackDependencies();
  }

  void ClearBackpackDependencies()
  {
    foreach (var cell in cells)
    {
      cell.data.BackpackCell = null;
    }
  }

  public T GetModifier<T>() where T : ItemModifier
  {
    var mods = modifiers.OfType<T>().ToArray();

    return mods.Length > 0 ? mods[0] : null;
  }

  public void Apply()
  {
    // foreach (var cell in cells)
    // {
    //   cell.backpackCell = cell.backpackCellCandidate;
    // }
    // foreach (var modifier in modifiers)
    // {
    //   ((IBackpackItemModifier)modifier).Apply();
    // }
  }

  public void Undo()
  {
    // foreach (var modifier in modifiers)
    // {
    //   ((IBackpackItemModifier)modifier).Undo();
    // }
    // foreach (var cell in cells)
    // {
    //   cell.backpackCell = null;
    // }
  }
}
