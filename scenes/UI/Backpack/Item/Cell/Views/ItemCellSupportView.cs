using Godot;
using System;

public partial class ItemCellSupportView : ItemCellDefaultView
{
  [Export] StyleBox activeStyle;
  [Export] StyleBox defaultStyle;
  [Export] Panel panel;

  public override void _Process(double delta)
  {
    var currentStyle = cell.backpackCell?.item == null || cell.backpackCell.item == cell.item ? defaultStyle : activeStyle;

    panel.AddThemeStyleboxOverride("panel", currentStyle);
  }
}
