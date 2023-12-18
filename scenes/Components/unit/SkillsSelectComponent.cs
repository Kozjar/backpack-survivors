using Godot;
using System;
using System.Linq;

public partial class SkillsSelectComponent : Node
{
  [Export] SkillsComponent skillsComponent;
  [Export] Node uiContainer;
  [Export] PackedScene skillSelectionAsset;
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
    skillStore.PickSkill(skill);
    skillsComponent.TakeSkill(skill);

    skillSelectionScene.QueueFree();
    GetTree().Paused = false;
  }
}
