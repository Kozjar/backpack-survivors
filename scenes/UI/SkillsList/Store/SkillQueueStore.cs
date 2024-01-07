using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SkillQueueStore : Control
{
  [Export] public SkillResource[] initialSkills;
  [Export] public SkillGlobalResource[] initialGlobalSkills;
  [Export] Control skillsContainer;
  [Export] PackedScene skillSelectionScene;
  [Export] SkillsListStash skillsListStash;
  [Export] Node globalSkillsContainer;
  [Export] SkillsList skillsList;

  public static SkillQueueStore instance;

  public List<SkillResource> availableSkills;
  public List<SkillGlobalResource> availableGlobalSkills;

  public override void _Ready()
  {
    base._Ready();
    instance = this;
    availableSkills = new List<SkillResource>(initialSkills);
    availableGlobalSkills = new List<SkillGlobalResource>(initialGlobalSkills);
    // ShowSkillSelection(1, 1f);
  }

  public List<SkillBaseResource> GetSequense(int amount, List<SkillBaseResource> list)
  {
    var remainingSkills = new List<SkillBaseResource>(list);
    var result = new List<SkillBaseResource>();

    for (int i = 0; i < amount; i++)
    {
      var skill = SkillListGlobal.RandomWeighted(remainingSkills);

      if (skill != null)
      {
        remainingSkills.Remove(skill);
        result.Add(skill);
      }
    }

    return result;
  }

  public void OnLevelUp(int level, float mxXp)
  {
    Visible = true;
    SkillListGlobal.instance.ToggleGameplay();

    if (level % 5 == 0)
    {
      OfferGlobalSkills();
    }
    else
    {
      OfferQueueSkills();
    }
  }

  void OfferQueueSkills()
  {
    var skillsOffer = GetSequense(3, availableSkills.ToList<SkillBaseResource>());
    ShowSkillSelection(skillsOffer, (skill) => AddSkillToStash((SkillResource)skill));
  }

  void OfferGlobalSkills()
  {
    var skillsOffer = GetSequense(3, availableGlobalSkills.ToList<SkillBaseResource>());
    QueueSkillSelection.SkillSelectedEventHandler callback = (skill) =>
    {
      globalSkillsContainer.AddChild(((SkillGlobalResource)skill).SkillScene.Instantiate());
      Close();
      SkillListGlobal.instance.ResumeGameplay();
    };
    ShowSkillSelection(skillsOffer, callback);
  }

  public void ShowSkillSelection(List<SkillBaseResource> skillsOffer, QueueSkillSelection.SkillSelectedEventHandler Callback)
  {
    // var skillsOffer = GetSequense(3);
    foreach (var skill in skillsOffer)
    {
      var skillSelection = skillSelectionScene.Instantiate<QueueSkillSelection>();
      skillSelection.Init(skill);
      // skillSelection.SkillSelected += () => AddSkillToStash(skill);
      skillSelection.SkillSelected += Callback;
      skillsContainer.AddChild(skillSelection);
    }
  }

  void AddSkillToStash(SkillResource skillResource)
  {
    skillsListStash.AddSkillFromRsource(skillResource);
    Close();
    skillsList.Open();
  }
  void Close()
  {
    Visible = false;
    skillsContainer.GetChildren().ToList().ForEach(child => child.QueueFree());
  }
}
