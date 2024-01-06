using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SkillQueueStore : Control
{
  [Export] SkillResource[] availableSkills;
  [Export] Control skillsContainer;
  [Export] PackedScene skillSelectionScene;
  [Export] SkillsListStash skillsListStash;

  public List<SkillResource> AvailableSkills => availableSkills.ToList();

  public override void _Ready()
  {
    base._Ready();
    // ShowSkillSelection(1, 1f);
  }

  private SkillResource GetRandomSkill(List<SkillResource> skills)
  {
    if (skills.Count == 0) return null;
    var totalWeight = skills.Sum((skill) => skill.Weight);
    var seedWeight = GD.Randi() % totalWeight;

    int tmpWeight = 0;

    return skills.Find((skill) =>
    {
      tmpWeight += skill.Weight;

      return tmpWeight > seedWeight;
    });
  }

  public List<SkillResource> GetSequense(int amount)
  {
    var remainingSkills = new List<SkillResource>(AvailableSkills);
    var result = new List<SkillResource>();

    for (int i = 0; i < amount; i++)
    {
      var skill = GetRandomSkill(remainingSkills);
      GD.Print(skill);

      if (skill != null)
      {
        remainingSkills.Remove(skill);
        result.Add(skill);
      }
    }

    return result;
  }

  public void ShowSkillSelection(int level, float mxXp)
  {
    Visible = true;
    SkillListGlobal.instance.ToggleGameplay();
    var skillsOffer = GetSequense(3);
    foreach (var skill in skillsOffer)
    {
      var skillSelection = skillSelectionScene.Instantiate<QueueSkillSelection>();
      skillSelection.Init(skill);
      skillSelection.SkillSelected += () => AddSkillToStash(skill);
      skillsContainer.AddChild(skillSelection);
    }
  }

  void AddSkillToStash(SkillResource skillResource)
  {
    skillsListStash.AddSkillFromRsource(skillResource);
    Visible = false;
    SkillListGlobal.instance.ToggleGameplay();
    skillsContainer.GetChildren().ToList().ForEach(child => child.QueueFree());
  }
}
