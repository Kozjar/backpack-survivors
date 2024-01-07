using Godot;
using System;

public partial class AttacksAtOnceTier1 : Achievement
{
  [Export] SkillResource newSkill;

  public void Validate()
  {
    if (GetTree().GetNodesInGroup("attack").Count >= 10)
    {
      markCompleted = true;
    }
  }

  public override void GrantReward()
  {
    base.GrantReward();
    SkillQueueStore.instance.availableSkills.Add(newSkill);
  }
}
