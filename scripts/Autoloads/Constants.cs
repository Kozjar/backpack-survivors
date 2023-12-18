using Godot;
using System;

public partial class Constants : Node
{
  public static int cellSize = 100;

  public static Backpack GetBackpack(Node node) {
    return node.GetTree().Root.GetNode<Backpack>("root/UIContainer/BackpackInventory/Backpack");
  }
}
