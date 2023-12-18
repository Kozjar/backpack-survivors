using Godot;
using System;

public abstract partial class Autoload<T>: Node where T : class
{
  public static T instance;

  public override void _Ready()
  {
    instance = this as T;
  }
}
