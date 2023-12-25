using Godot;
using System;

public partial class ItemCellSupport : ItemCellConfig
{
  [Signal] public delegate void ItemChangedEventHandler(BackpackItemData newItem, BackpackItemData previousItem);
  // private BackpackCell backpackCell;
  // public new BackpackCell BackpackCell
  // {
  //   get => backpackCell; set
  //   {
  //     if (backpackCell.Item != affectedItem)
  //     {
  //       EmitSignal(SignalName.ItemChanged, backpackCell.Item, affectedItem);
  //     }
  //     backpackCell = value;

  //     value.ItemChanged += OnBackpackCellItemChanged;
  //     backpackCell.ItemChanged -= OnBackpackCellItemChanged;
  //   }
  // }
  // private BackpackItemData affectedItem => backpackCell.Item;

  void OnBackpackCellItemChanged(BackpackItemData newItem)
  {
    // EmitSignal(SignalName.ItemChanged, newItem, affectedItem);
  }
}
