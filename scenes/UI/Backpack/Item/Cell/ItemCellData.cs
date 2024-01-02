using Godot;
using System;
using System.Linq;

public partial class ItemCellData : Node
{
  [Signal] public delegate void BackpackCellChangedEventHandler(BackpackCell backpackCell, BackpackCell previous);
  [Export] public BackpackItemData originItem;
  BackpackCell backpackCell;

  public BackpackCell BackpackCell
  {
    get => backpackCell;
    set
    {
      EmitSignal(SignalName.BackpackCellChanged, value, backpackCell);
      backpackCell = value;
    }
  }

  public bool HasModifier<T>() where T : ItemModifier
  {
    return Array.Find(AssignedModifiers, mod => mod is T) != null;
  }

  public ItemModifier[] AssignedModifiers => originItem.modifiers.Where(ContainsThisCell).ToArray();

  public bool ContainsThisCell(ItemModifier modifier)
  {
    return Array.Find(modifier.cellConfigs, config => config.data == this) != null;
  }
}
