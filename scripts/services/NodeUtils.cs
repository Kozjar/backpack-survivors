using System.Collections.Generic;
using Godot;

class NodeUtils
{
  static  public List<T> GetChildrenInGroup<T>(Node node, string groupName) where T : Node
  {
    var list = new List<T>();

    foreach (var child in node.GetChildren())
    {
      if (child.IsInGroup(groupName))
      {
        list.Add((T)child);
      }
    }

    return list;
  }
}