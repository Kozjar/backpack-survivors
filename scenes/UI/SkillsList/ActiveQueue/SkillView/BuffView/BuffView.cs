using Godot;
using System;

public partial class BuffView : SkillTitleView
{
  public Buff buff => (Buff)skillData;
}
