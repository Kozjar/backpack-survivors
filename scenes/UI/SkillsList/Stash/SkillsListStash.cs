using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SkillsListStash : PanelContainer, ISkillContainer
{
  [Export] public Control skillsContainer;
  [Export] public PackedScene stashSkillView;
  [Export] public SkillResource[] initialItems;
  [Export] public SkillDropPreview dropPreview;

  public override void _Ready()
  {
    foreach (var item in initialItems)
    {
      AddSkillFromRsource(item);
    }

    dropPreview.skillDropped += (SkillDragData dragData) => AddSkill(dragData.skillData);

    SkillListGlobal.instance.DragStarted += (SkillData _) => dropPreview.ShowDropPreview();
    SkillListGlobal.instance.DragEnded += dropPreview.HideDropPreview;
  }

  public void AddSkillFromRsource(SkillResource skillResource)
  {
    var skill = SkillFactory.BuildSkill(skillResource);
    AddSkill(skill);
  }

  public void AddSkill(SkillData skillData)
  {
    if (skillData is Trigger && ((Trigger)skillData).Attack != null)
    {
      AddSkill(((Trigger)skillData).Attack);
    }
    skillData.Reset();
    var stashSkill = stashSkillView.Instantiate<StashSkillView>();
    stashSkill.Init(this, skillData);

    skillsContainer.AddChild(stashSkill);
  }

  public void RemoveSkill(SkillData skillData)
  {
    var skills = skillsContainer.GetChildren().OfType<StashSkillView>().ToList();
    var skillToRemove = skills.Find(view => view.skillData == skillData);
    skillToRemove.QueueFree();
  }
}
