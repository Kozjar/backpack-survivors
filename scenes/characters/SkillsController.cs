using Godot;
using System;
using System.Linq;

public partial class SkillsController : Node
{
  [Export] Node uiContainer;
  [Export] PackedScene skillSelectionAsset;
  public PlayerStatGroup playerStatGroup = new();
  SkillsCollection selectedSkills = new();
  SkillStore skillStore = new();
  SkillSelection skillSelectionScene;

  public void ShowSkillSelection(int level, float maxXp) {
    GetTree().Paused = true;

    skillSelectionScene = skillSelectionAsset.Instantiate<SkillSelection>();
    uiContainer.AddChild(skillSelectionScene);

    skillSelectionScene.ShowSkills(skillStore.GetSequense(3));
    skillSelectionScene.SkillSelectedEvent += TakeSkill;
  }

  private void TakeSkill(SkillAbstract skill) {
    if (!selectedSkills.skills.Contains(skill)) {
      selectedSkills.skills.Add(skill);
    }

    skillStore.PickSkill(skill);
    playerStatGroup.ApplySkills(selectedSkills.skills);

    skillSelectionScene.QueueFree();
    GetTree().Paused = false;
  }
}
