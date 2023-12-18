using Godot;
using System;

public partial class PermanentAtackerComponent : AttackComponent
{
    public override void _Ready()
    {
        InstantiateAttack();
    }
}
