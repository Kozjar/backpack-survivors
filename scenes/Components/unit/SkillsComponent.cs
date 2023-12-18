using Godot;
using System;
using System.Linq;

public partial class SkillsComponent : Node
{
  [Export] StatsComponent statsComponent;
  SkillsCollection selectedSkills = new();

  public void TakeSkill(SkillAbstract skill) {
    if (!selectedSkills.skills.Contains(skill)) {
      selectedSkills.skills.Add(skill);
    }

    statsComponent.statGroup.ApplySkills(selectedSkills.skills);
  }
}
