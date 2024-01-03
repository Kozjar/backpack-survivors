using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class WeaponStatsModifier : ItemModifier
{
  [Export] StatType statType;
  [Export] StatChangeType operatorType;
  [Export] float diff;
  // [Export] ItemCellSupport[] supportCells;
  // BackpackItemData affectedItems = new HashSet<>();
  public List<BackpackItemData> supportedItems = new();

  public override void _Ready()
  {
    foreach (var cell in cellConfigs)
    {
      // cell
    }
  }

  // WeaponModifier[] affectedWeapons
  // {
  //   get
  //   {
  //     var weapons = new HashSet<WeaponModifier>();

  //     foreach (var cell in supportCells)
  //     {
  //       var affectedItem = cell.backpackCell?.item;

  //       if (affectedItem != null && affectedItem != cell.originItem)
  //       {
  //         var modifiers = affectedItem.modifiers.OfType<WeaponModifier>();
  //         foreach (var modifier in modifiers)
  //         {
  //           weapons.Add(modifier);
  //         }
  //       }
  //     }

  //     return weapons.ToArray();
  //   }
  // }

  public void Apply(BackpackItemData item)
  {
    var weapon = item.GetModifier<WeaponModifier>();

    weapon.stats.StatGroup.GetStat(statType).UpdateByType(operatorType, diff);
  }

  public void Undo(BackpackItemData item)
  {
    var weapon = item.GetModifier<WeaponModifier>();

    weapon.stats.StatGroup.GetStat(statType).UpdateByType(operatorType, diff);
  }
}
